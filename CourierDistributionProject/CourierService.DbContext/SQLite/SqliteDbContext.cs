using CourierService.DbContext.SQLite.Model;
using CourierService.DbContextModels.SQLite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLite
{
    public class SqliteDbContext
    {
        private string fileName;
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        private SQLiteHashSet<Category> categories;
        private ICollection<Category> categoriesToAdd;

        public SqliteDbContext(string fileName = "Vehicles.db")
        {
            this.fileName = fileName;
            this.conn = new SQLiteConnection(String.Format($"data source={this.fileName}"));
            this.categories = new SQLiteHashSet<Category>();
            this.categoriesToAdd = new SQLiteHashSet<Category>();
            this.CreateDbFile();
        }

        public SQLiteHashSet<Category> Categories
        {
            get
            {
                this.categories.Clear();
                ICollection<SQLiteDataReader> reader = this.GetReaderCollection("Categories");
                foreach (var item in reader)
                {
                    this.categories.Add(new Category() { CategoryName = item["CategoryName"].ToString() });
                }
                this.categories.OnAdd += new EventHandler(l_OnAdd);
                return this.categories;
            }
            private set
            {
                this.categories = value;
            }
        }

        private void l_OnAdd(object sender, EventArgs e)
        {
            Console.WriteLine("Element added...");
        }

        public void SaveChanges()
        {
        }

        public void AddCategory(Category category)
        {
            this.InsertStatement("Categories", new string[1] { "CategoryName" }, new string[1] { category.CategoryName });
        }

        private void CreateDbFile()
        {
            if (!File.Exists(this.fileName))
            {
                SQLiteConnection.CreateFile(this.fileName);
                this.CreateDb();
            }
        }

        private void CreateDb()
        {
            string createQuery = SQLiteConstant.SQLiteConstant.CREATE_DATABASE_QUERY;
            using (this.cmd = new SQLiteCommand(this.conn))
            {
                this.conn.Open();
                this.cmd.CommandText = createQuery;
                this.cmd.ExecuteNonQuery();
                this.conn.Close();
            }
        }

        private ICollection<SQLiteDataReader> GetReaderCollection(string table)
        {
            ICollection<SQLiteDataReader> readerCollection = new HashSet<SQLiteDataReader>();
            using (this.cmd = new SQLiteCommand())
            {
                this.conn.Open();
                this.cmd.CommandText = $"SELECT * FROM [{table}]";
                using (SQLiteDataReader reader = this.cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        readerCollection.Add(reader);
                    }
                }
                conn.Close();
            }
            return readerCollection;
        }

        private void InsertStatement(string tableName, string[] properties, string[] values)
        {
            using (this.cmd = new SQLiteCommand())
            {
                this.conn.Open();
                this.cmd.CommandText = string.Format($"INSERT INTO {tableName} ({string.Join(",", properties)}) VALUES('{string.Join(",", values)}');");
                this.cmd.ExecuteNonQuery();
                this.conn.Close();
            }
        }
    }
}
