//using CourierService.DbContextModels.SQLite;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CourierService.DbContext.SQLite.DataToLoad
//{
//    internal class VehicleBrandsData
//    {
//        internal bool AddAutoBrands()
//        {
//            var brandA = new Brand()
//            {
//                BrandName = "VW",
//                CategoryId = 1
//            };
//            var brandB = new Brand()
//            {
//                BrandName = "Volvo",
//                CategoryId = 1
//            };

//            using (var dbContext = new VehiclesDbContext())
//            {
//                dbContext.Brands.Add(brandA);
//                dbContext.Brands.Add(brandB);
//                dbContext.SaveChanges();
//            }

//            return true;
//        }

//        internal bool AddVansBrands()
//        {
//            var brandA = new Brand()
//            {
//                BrandName = "Mercedes-Benz",
//                CategoryId = 2
//            };
//            var brandB = new Brand()
//            {
//                BrandName = "Ford",
//                CategoryId = 2
//            };

//            using (var dbContext = new VehiclesDbContext())
//            {
//                dbContext.Brands.Add(brandA);
//                dbContext.Brands.Add(brandB);
//                dbContext.SaveChanges();
//            }

//            return true;
//        }

//        internal bool AddTruckBrands()
//        {
//            var brandA = new Brand()
//            {
//                BrandName = "DAF",
//                CategoryId = 3
//            };
//            var brandB = new Brand()
//            {
//                BrandName = "Scania",
//                CategoryId = 3
//            };

//            using (var dbContext = new VehiclesDbContext())
//            {
//                dbContext.Brands.Add(brandA);
//                dbContext.Brands.Add(brandB);
//                dbContext.SaveChanges();
//            }

//            return true;
//        }

//        internal bool AddAirplaneBrands()
//        {
//            var brandA = new Brand()
//            {
//                BrandName = "LZ-TMH",
//                CategoryId = 4
//            };
//            var brandB = new Brand()
//            {
//                BrandName = "LZ-DBF",
//                CategoryId = 4
//            };

//            using (var dbContext = new VehiclesDbContext())
//            {
//                dbContext.Brands.Add(brandA);
//                dbContext.Brands.Add(brandB);
//                dbContext.SaveChanges();
//            }

//            return true;
//        }
//    }
//}
