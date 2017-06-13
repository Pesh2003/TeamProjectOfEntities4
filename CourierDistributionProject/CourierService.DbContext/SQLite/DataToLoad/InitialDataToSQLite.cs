//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CourierService.DbContext.SQLite.DataToLoad
//{
//    public class InitialDataToSQLite
//    {
//        public bool LoadData()
//        {
//            var vehicleCategories = new VehicleCategoriesData();
//            vehicleCategories.AddCategories();

//            var vehicleBrands = new VehicleBrandsData();
//            vehicleBrands.AddAutoBrands();
//            vehicleBrands.AddVansBrands();
//            vehicleBrands.AddTruckBrands();
//            vehicleBrands.AddAirplaneBrands();

//            var vehicleModels = new VehicleModelsData();
//            vehicleModels.AddAutoModels();
//            vehicleModels.AddVanModels();
//            vehicleModels.AddTruckModels();
//            vehicleModels.AddAirplanesModels();

//            return true;
//        }
//    }
//}
