//using CourierService.DbContextModels.SQLite;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CourierService.DbContext.SQLite.DataToLoad
//{
//    internal class VehicleCategoriesData
//    {
//        internal bool AddCategories()
//        {
//            Category categoryA = new Category()
//            {
//                CategoryName = "Auto"
//            };
//            Category categoryB = new Category()
//            {
//                CategoryName = "Vans"
//            };
//            Category categoryC = new Category()
//            {
//                CategoryName = "Truck"
//            };
//            Category categoryD = new Category()
//            {
//                CategoryName = "Airplane"
//            };

//            using (var dbContext = new VehiclesDbContext())
//            {
//                dbContext.Categories.Add(categoryA);
//                dbContext.Categories.Add(categoryB);
//                dbContext.Categories.Add(categoryC);
//                dbContext.Categories.Add(categoryD);
//                dbContext.SaveChanges();
//            }

//            return true;
//        }
//    }
//}
