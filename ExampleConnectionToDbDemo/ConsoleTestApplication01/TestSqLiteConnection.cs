//namespace ConsoleTestApplication01
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Data.SQLite;
//
//    internal class TestSqLiteConnection
//    {
//        private static string fileName = "sample.db3";
//        private static SQLiteConnection conn = new SQLiteConnection(String.Format($"data source={fileName}"));
//        private static SQLiteCommand cmd = new SQLiteCommand(conn);
//
//        internal static bool CreateFile()
//        {
//            SQLiteConnection.CreateFile(fileName);
//            return true;
//        }
//
//        internal static bool CreateUsers()
//        {
//            try
//            {
//                string createQuery = @"CREATE TABLE IF NOT EXISTS
//                                [Users] (
//                                    [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
//                                    [Name] NVARCHAR(256) NULL
//                                )";
//                conn.Open();
//                cmd.CommandText = createQuery;
//                cmd.ExecuteNonQuery();
//                cmd.CommandText = "INSERT INTO Users (Name) VALUES('Alex')";
//                cmd.ExecuteNonQuery();
//                conn.Close();
//
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }
//
//        internal static IList<User> GetUsers()
//        {
//            IList<User> list = new List<User>();
//            conn.Open();
//            cmd.CommandText = "SELECT * FROM Users";
//            using (SQLiteDataReader reader = cmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    list.Add(new User(int.Parse(reader["Id"].ToString()), reader["Name"].ToString()));
//                }
//            }
//
//            conn.Close();
//            return list;
//        }
//    }
//}
