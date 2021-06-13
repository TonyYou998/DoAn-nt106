using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Server
{
    class Sqlite_control
    {
        private SQLiteConnection sqlite_conn;
   
        public Sqlite_control()
        {
            sqlite_conn = CreateConnection();
            CreateTable();
        }
        List<UserModel> Users = new List<UserModel>();
        List<RoomModel> Rooms = new List<RoomModel>();
        private SQLiteConnection CreateConnection()
        {
            sqlite_conn = new SQLiteConnection("Data Source=Database.db; Version = 3; New = True; Compress = True; ");
            try
            {
                sqlite_conn.Open();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
            return sqlite_conn;
        }

        private void CreateTable()
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE Users  (Username TEXT NOT NULL PRIMARY KEY, RoomID int, Online int, isHost int)";
            string Createsql2 = "CREATE TABLE Room  (RoomID INTEGER PRIMARY KEY AUTOINCREMENT, Roomname TEXT NOT NULL)";
            string Createsql3 = "CREATE TABLE Horse (" +
                "Username TEXT, RoomID int, color TEXT, x int, y int," +
                "FOREIGN KEY (Username) REFERENCES Users(Username)" +
                ")";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql2;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql3;
            sqlite_cmd.ExecuteNonQuery();
        }

        public List<string> GetListUserInRoom(int roomid)
        {
            List<string> luser = new List<string>();
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"SELECT Username from Users where RoomId = {roomid} and Online=1";

            using (var reader = sqlite_cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    luser.Add(reader[0].ToString());
                }
            }

            return luser;
        }
        public void SetHost(string username, int mode = 0) // mode = 0 : normal, = 1 : host
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"UPDATE Users SET isHost = {mode.ToString()} where Username = '{username}'";
            sqlite_cmd.ExecuteNonQuery();
        }

        public void SetUserOnline(string username, int mode=0) // mode = 0 : offline, = 1 : online
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"UPDATE Users SET Online = {mode.ToString()} where Username = '{username}'";
            sqlite_cmd.ExecuteNonQuery();        
        }

        public void SetRoomID(string username, int roomID)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"UPDATE Users SET RoomID = {roomID} where Username = '{username}'";
            sqlite_cmd.ExecuteNonQuery();
        }

        public bool IsUserOnline(string username)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"SELECT Online from Users where Username = '{username}'";

            using (var reader = sqlite_cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    int status = int.Parse(reader[0].ToString());
                    if (status == 1)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }


        public bool checkUserExist(string username)
        {
            ReadUserData();
            foreach (var u in Users)
            {
                if (u.Name == username)
                {
                    return true;
                }
            }
            return false;
        }
        public void Adduser(string username)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Users " +
                $"(Username) VALUES('{username}'); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        public void Adduser(string username, string roomID)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Users " +
                $"(Username, RoomID) VALUES('{username}','{roomID}'); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        public void AddRoom(string Title)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Room " +
                $"(Roomname) VALUES('{Title}'); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        public List<UserModel> ReadUserData()
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Users";
            Users.Clear();
            using (var reader = sqlite_cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bool res; int id;

                    var User = new UserModel();
                    res = int.TryParse(reader["RoomID"].ToString(), out id);
                    User.RoomID = res ? id : 0;

                    User.Name = reader["Username"].ToString();
                    User.Online = int.Parse(reader["Online"].ToString());
                    Users.Add(User);
                }
            }

            return Users;
        }

        public List<RoomModel> ReadRoomData()
        {
            SQLiteCommand sql1;
            SQLiteCommand sql2;

            sql1 = sqlite_conn.CreateCommand();
            sql2 = sqlite_conn.CreateCommand();

            sql1.CommandText = "SELECT * FROM Room";
            Rooms.Clear();

            using (var reader = sql1.ExecuteReader())
            {
                while (reader.Read())
                {
                    var room = new RoomModel();
                    room.RoomID = int.Parse(reader["RoomID"].ToString());
                    room.RoomName = reader["Roomname"].ToString();

                    sql2.CommandText = $"SELECT COUNT(Username) from Users where RoomID = {room.RoomID }";

                    using (var read2 = sql2.ExecuteReader())
                    {
                        if (read2.Read())
                        {
                            room.Members_num = int.Parse(read2[0].ToString());
                        }
                    }

                    Rooms.Add(room);
                }
            }

            return Rooms;
        }
    }
}