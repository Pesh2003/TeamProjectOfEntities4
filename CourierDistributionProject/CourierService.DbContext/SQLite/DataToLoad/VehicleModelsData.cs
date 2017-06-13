//using CourierService.DbContextModels.SQLite;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CourierService.DbContext.SQLite.DataToLoad
//{
//    internal class VehicleModelsData
//    {
//        internal bool AddAutoModels()
//        {
//            var modelA = new Model()
//            {
//                ModelName = "Golf",
//                BrandId = 1
//            };
//            var modelB = new Model()
//            {
//                ModelName = "Passat",
//                BrandId = 1
//            };
//            var modelC = new Model()
//            {
//                ModelName = "S80",
//                BrandId = 2
//            };
//            var modelD = new Model()
//            {
//                ModelName = "V60",
//                BrandId = 2
//            };

//            using (var dbContext = new VehiclesDbContext())
//            {
//                dbContext.Models.Add(modelA);
//                dbContext.Models.Add(modelB);
//                dbContext.Models.Add(modelC);
//                dbContext.Models.Add(modelD);
//                dbContext.SaveChanges();
//            }

//            return true;
//        }

//        internal bool AddVanModels()
//        {
//            var modelA = new Model()
//            {
//                ModelName = "SPRINTER 313",
//                BrandId = 3
//            };
//            var modelB = new Model()
//            {
//                ModelName = "TRANSIT 2.2TDCI",
//                BrandId = 4
//            };

//            using (var dbContext = new VehiclesDbContext())
//            {
//                dbContext.Models.Add(modelA);
//                dbContext.Models.Add(modelB);
//                dbContext.SaveChanges();
//            }

//            return true;
//        }

//        internal bool AddTruckModels()
//        {
//            var modelA = new Model()
//            {
//                ModelName = "XF 105.410",
//                BrandId = 5
//            };
//            var modelB = new Model()
//            {
//                ModelName = "R124.400",
//                BrandId = 6
//            };

//            using (var dbContext = new VehiclesDbContext())
//            {
//                dbContext.Models.Add(modelA);
//                dbContext.Models.Add(modelB);
//                dbContext.SaveChanges();
//            }

//            return true;
//        }

//        internal bool AddAirplanesModels()
//        {
//            var modelA = new Model()
//            {
//                ModelName = "P2006 T",
//                BrandId = 7
//            };
//            var modelB = new Model()
//            {
//                ModelName = "P92 JS",
//                BrandId = 8
//            };

//            using (var dbContext = new VehiclesDbContext())
//            {
//                dbContext.Models.Add(modelA);
//                dbContext.Models.Add(modelB);
//                dbContext.SaveChanges();
//            }

//            return true;
//        }
//    }
//}
