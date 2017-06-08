using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLServer.InitialDataToLoad
{
    public class InicialDataToSQLServer
    {        
        public void InitialDataToSQLServeLoad()
        {
            //AddCities();
            //AddServiceTypes();
            //AddOffices();
            //AddServiceOptions();
            //AddServices();

            var dataCities = new DataCities();
            var dataServiceTypes = new DataServiceTypes();
            var dataOffices = new DataOffices();
            var dataSeviceOptions = new DataServiceOptions();
            var dataServices = new DataServices();

            dataCities.AddCities();
            dataServiceTypes.AddServiceTypes();
            dataOffices.AddOffices();
            dataSeviceOptions.AddServiceOptions();
            dataServices.AddServices();
        }

    }
}
