using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Cờ_cá_ngựa
{
    class Sqlite_control
    {
        public Sqlite_control()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            try // check exist database
            {
                var cmd = sqlite_conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Users";
                cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {
                CreateTable(sqlite_conn);
                InsertData(sqlite_conn);
            }
            ReadUserData(sqlite_conn);
            ReadRoomData(sqlite_conn);
            
        }
        List<UserModel> infos = new List<UserModel>();
        List<RoomModel> Rooms = new List<RoomModel>();
        private SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=Database.db; Version = 3; New = True; Compress = True; ");
         try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            return sqlite_conn;
        }

        private void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE Users (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, RoomID int)";
            string Createsql2 = "CREATE TABLE Room  (RoomID int, Title TEXT NOT NULL, StartTime TEXT NOT NULL)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql2;
            sqlite_cmd.ExecuteNonQuery();
        }

        private void InsertData(SQLiteConnection conn)
        {
            Adduser(conn, new string []{ "Duy", "1" });
            Adduser(conn, new string[] { "Chien", "1" });
            Adduser(conn, new string[] { "Tan", "1" });
            AddRoom(conn, new string[] { "1", "chickens","11:20"});

        }
        private void Adduser(SQLiteConnection conn, string[] arr)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Users " +
                $"(Name, RoomID) VALUES('{arr[0]}','{arr[1]}'); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        private void AddRoom(SQLiteConnection conn, string[] arr)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Room " +
                $"(RoomID, Title, StartTime) VALUES('{arr[0]}','{arr[1]}','{arr[2]}'); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        private void ReadUserData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Users";

            using (var reader = sqlite_cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var info = new UserModel();
                    info.ID = int.Parse(reader["ID"].ToString());
                    info.Name = reader["Name"].ToString();
                    info.RoomID = int.Parse(reader["RoomID"].ToString());
                    infos.Add(info);
                }
            }
        }

        private void ReadRoomData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Room";

            using (var reader = sqlite_cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var room = new RoomModel();
                    room.RoomID = int.Parse(reader["RoomID"].ToString());
                    room.Title = reader["Title"].ToString();
                    room.StartTime = reader["StartTime"].ToString();
                    Rooms.Add(room);
                }
                conn.Close();
            }
        }
        public List<UserModel> GetUserData()
        {
            return infos;
        }
        public List<RoomModel> GetRoomData()
        {
            return Rooms;
        }
    }
}