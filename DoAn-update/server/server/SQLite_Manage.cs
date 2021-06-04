using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Cờ_cá_ngựa
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
        List<UserModel> infos = new List<UserModel>();
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
            string Createsql2 = "CREATE TABLE Room  (RoomID int, Title TEXT NOT NULL, StartTime TEXT NOT NULL)";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql2;
            sqlite_cmd.ExecuteNonQuery();
        }

        private void InsertData()
        {
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

            return infos;
        }

        public List<RoomModel> ReadRoomData()
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
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
                sqlite_conn.Close();
            }

            return Rooms;
        }
    }
}