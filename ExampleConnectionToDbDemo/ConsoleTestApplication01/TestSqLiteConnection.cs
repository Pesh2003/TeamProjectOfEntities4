namespace ConsoleTestApplication01
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;

    internal class TestSqLiteConnection
    {
        private static string fileName = "sample.db";
        private static SQLiteConnection conn = new SQLiteConnection(String.Format($"data source={fileName}"));
        private static SQLiteCommand cmd = new SQLiteCommand(conn);

        internal static bool CreateFile()
        {
            SQLiteConnection.CreateFile(fileName);
            return true;
        }

        internal static bool CreateDb()
        {
            string createQuery = @"PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS [CarCategories] (
       [CategoryId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [CategoryName] NVARCHAR(32) NULL
);
CREATE UNIQUE INDEX Unq_Category ON [CarCategories]([CategoryName]);

CREATE TABLE IF NOT EXISTS [CarBrands] (
       [BrandId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [BrandName] NVARCHAR(32) NULL
);	
CREATE UNIQUE INDEX Unq_Brand ON [CarBrands]([BrandName]);

CREATE TABLE IF NOT EXISTS [CarModels] (
       [ModelId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [ModelName] NVARCHAR(32) NULL
);		
CREATE UNIQUE INDEX Unq_Model ON [CarModels]([ModelName]);

CREATE TABLE IF NOT EXISTS [Cars] (
       [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	   [CategoryId] INTEGER NOT NULL,
	   [BrandId] INTEGER NOT NULL,
	   [ModelId] INTEGER NOT NULL,
	   [Details] TEXT NULL,
       [IsTaken] INTEGER DEFAULT 0 CHECK([IsTaken] IN (0,1)),
	   FOREIGN KEY ([CategoryId]) REFERENCES [CarCategories] ([CategoryId]),
	   FOREIGN KEY ([BrandId]) REFERENCES [CarBrands] ([BrandId]),
	   FOREIGN KEY ([ModelId]) REFERENCES [CarModels] ([ModelId])
);";

            conn.Open();
            cmd.CommandText = createQuery;
            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        internal static bool CreateUsers()
        {
            try
            {
                string createQuery = @"CREATE TABLE IF NOT EXISTS
                                [Users] (
                                    [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                    [Name] NVARCHAR(256) NULL
                                )";
                conn.Open();
                cmd.CommandText = createQuery;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Users (Name) VALUES('Alex')";
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static IList<User> GetUsers()
        {
            IList<User> list = new List<User>();
            conn.Open();
            cmd.CommandText = "SELECT * FROM [Users]";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new User(int.Parse(reader["Id"].ToString()), reader["Name"].ToString()));
                }
            }

            conn.Close();
            return list;
        }
    }
}
