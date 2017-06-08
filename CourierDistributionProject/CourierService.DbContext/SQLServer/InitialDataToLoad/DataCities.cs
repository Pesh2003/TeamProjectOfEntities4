using CourierService.DbContextModels.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLServer.InitialDataToLoad
{
    class DataCities
    {
        internal void AddCities()
        {
            var dbContext = new CorierServiceContext();

            var city1 = new City() { CityName = "Созопол" };
            var city2 = new City() { CityName = "София" };
            var city3 = new City() { CityName = "Монтана" };
            var city4 = new City() { CityName = "Карлово" };
            var city5 = new City() { CityName = "Айтос" };
            var city6 = new City() { CityName = "Хасково" };
            var city7 = new City() { CityName = "Варна" };

            dbContext.Cities.Add(city1);
            dbContext.Cities.Add(city2);
            dbContext.Cities.Add(city3);
            dbContext.Cities.Add(city4);
            dbContext.Cities.Add(city5);
            dbContext.Cities.Add(city6);
            dbContext.Cities.Add(city7);

            dbContext.SaveChanges();
        }
    }
}
