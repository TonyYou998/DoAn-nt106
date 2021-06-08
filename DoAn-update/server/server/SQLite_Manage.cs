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
            try // check exist database
            {
                var cmd = sqlite_conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Users";
                cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {
                CreateTable();
                InsertData();
            }            
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
            string Createsql = "CREATE TABLE Users (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, RoomID int)";
            string Createsql2 = "CREATE TABLE Room  (RoomID int, RoomName TEXT NOT NULL, StartTime TEXT NOT NULL)";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql2;
            sqlite_cmd.ExecuteNonQuery();
        }

        private void InsertData()
        {
        }
        public bool Adduser(string username)
        {

            ReadUserData();
            foreach(var u in Users)
            {
                if(u.Name == username)
                {
                    return false;
                }
            }
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Users " +
                $"(Name) VALUES('{username}'); ";
            sqlite_cmd.ExecuteNonQuery();
            return true;
        }

        public void Adduser(string username, string roomID)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Users " +
                $"(Name, RoomID) VALUES('{username}','{roomID}'); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        public void AddRoom(string RoomID ,string Title , string StartTime)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Room " +
                $"(RoomID, Title, StartTime) VALUES('{RoomID}','{Title}','{StartTime}'); ";
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
                    var User = new UserModel();
                    User.ID = int.Parse(reader["ID"].ToString());
                    User.Name = reader["Name"].ToString();
                   // User.RoomID = int.Parse(reader["RoomID"].ToString());
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
                    room.RoomName = reader["Title"].ToString();
                    room.StartTime = reader["StartTime"].ToString();

                    sql2.CommandText = $"SELECT COUNT(Name) from Users where RoomID = {room.RoomID }";

                    using (var read2 = sql2.ExecuteReader())
                    {
                        if (read2.Read())
                        {
                            room.Members_num = int.Parse(read2[0].ToString());
                        }
                    }

                    Rooms.Add(room);
                }
                sqlite_conn.Close();
            }

            


            return Rooms;
        }

        private int checkUserExist(string username, string roomname)
        {
            SQLiteCommand sql1, sql2;
            sql1 = sqlite_conn.CreateCommand();
            sql2 = sqlite_conn.CreateCommand();

            sql1.CommandText = $"SELECT RoomName from Room where RoomName = {roomname}";
            sql2.CommandText = $"SELECT u.Name" +
                  $"From Users u, Room r" +
                  $"where u.RoomID = r.RoomID" +
                  $"and u.Name = {username}";

            using (var reader = sql1.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (reader[0].ToString() == "-1")
                    {
                        return -1; // Phòng không tồn tại
                    }
                }
                else
                {
                    using (var reader2 = sql2.ExecuteReader())

                        if (reader2[0].ToString() != null)
                        {
                            return 0;
                        }
                }
            }

            return 1;
        }
    }
}