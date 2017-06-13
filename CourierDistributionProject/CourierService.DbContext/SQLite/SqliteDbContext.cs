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
        private SQLiteHashSet<Category> categoriesToAdd;
        private SQLiteHashSet<Brand> brands;
        private SQLiteHashSet<Brand> brandsToAdd;
        private SQLiteHashSet<DbContextModels.SQLite.Model> models;
        private SQLiteHashSet<DbContextModels.SQLite.Model> modelsToAdd;
        private SQLiteHashSet<Vehicle> vehicles;
        private SQLiteHashSet<Vehicle> vehiclesToAdd;

        public SqliteDbContext(string fileName = "Vehicles.db")
        {
            this.fileName = fileName;
            this.conn = new SQLiteConnection(String.Format($"data source={this.fileName}"));
            this.categories = new SQLiteHashSet<Category>();
            this.categoriesToAdd = new SQLiteHashSet<Category>();
            this.brands = new SQLiteHashSet<Brand>();
            this.brandsToAdd = new SQLiteHashSet<Brand>();
            this.models = new SQLiteHashSet<DbContextModels.SQLite.Model>();
            this.modelsToAdd = new SQLiteHashSet<DbContextModels.SQLite.Model>();
            this.vehicles = new SQLiteHashSet<Vehicle>();
            this.vehiclesToAdd = new SQLiteHashSet<Vehicle>();

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
                this.categories.OnAdd += new EventHandler(Hash_OnAdd);
                return this.categories;
            }
            private set
            {
                this.categories = value;
            }
        }
        
        public SQLiteHashSet<Brand> Brands
        {
            get
            {
                this.brands.Clear();
                ICollection<SQLiteDataReader> reader = this.GetReaderCollection("Brands");
                foreach (var item in reader)
                {
                    this.brands.Add(new Brand()
                    {
                        BrandName = item["BrandName"].ToString(),
                        CategoryId = int.Parse(item["CategoryId"].ToString())
                    });
                }
                return this.brands;
            }
            private set
            {
                this.brands = value;
            }
        }

        public SQLiteHashSet<DbContextModels.SQLite.Model> Models
        {
            get
            {
                this.models.Clear();
                ICollection<SQLiteDataReader> reader = this.GetReaderCollection("Models");
                foreach (var item in reader)
                {
                    this.models.Add(new DbContextModels.SQLite.Model()
                    {
                        ModelName = item["ModelName"].ToString(),
                        BrandId = int.Parse(item["BrandId"].ToString())
                    });
                }
                return this.models;
            }
            private set
            {
                this.models = value;
            }
        }

        public SQLiteHashSet<Vehicle> Vehicles
        {
            get
            {
                this.vehicles.Clear();
                ICollection<SQLiteDataReader> reader = this.GetReaderCollection("Vehicles");
                foreach (var item in reader)
                {
                    this.vehicles.Add(new Vehicle()
                    {
                        CategoryId = int.Parse(item["CategoryId"].ToString()),
                        BrandId = int.Parse(item["BrandId"].ToString()),
                        ModelId = int.Parse(item["ModelId"].ToString()),
                        IsTaken = int.Parse(item["IsTaken"].ToString())
                    });
                }
                return this.vehicles;
            }
            private set
            {
                this.vehicles = value;
            }
        }
        
        public void SaveChanges()
        {
        }

        public void AddCategory(Category category)
        {
            this.InsertStatement("Categories", new string[1] { "CategoryName" }, new string[1] { category.CategoryName });
        }

        public void AddBrand(Brand brand)
        {
            this.InsertStatement(
                "Brands", 
                new string[2] { "BrandName", "CategoryId" }, 
                new dynamic[2] { brand.BrandName, brand.CategoryId });
        }

        public void AddModel(DbContextModels.SQLite.Model model)
        {
            this.InsertStatement(
                "Models", 
                new string[2] { "ModelName", "BrandId" }, 
                new dynamic[2] { model.ModelName, model.BrandId });
        }

        public void AddVehicle(Vehicle vehicle)
        {
            this.InsertStatement(
                "Vehicles", 
                new string[4] { "CategoryId", "BrandId", "ModelId", "IsTaken" }, 
                new dynamic[4] { vehicle.CategoryId, vehicle.BrandId, vehicle.ModelId, 0 });
        }

        // Add sent object to added list to use the "SaveChanges" method correctly
        private void Hash_OnAdd(object sender, EventArgs e)
        {
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

        private void InsertStatement(string tableName, string[] properties, dynamic[] values)
        {
            using (this.cmd = new SQLiteCommand())
            {
                this.conn.Open();

                // TODO: Check variable type to include '' when having a varchar value
                this.cmd.CommandText = string.Format($"INSERT INTO {tableName} ({string.Join(",", properties)}) VALUES('{string.Join(",", values)}');");
                this.cmd.ExecuteNonQuery();
                this.conn.Close();
            }
        }
    }
}
