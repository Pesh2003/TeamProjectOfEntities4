using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.Postgre.InitialDataToLoad
{
   public class InitialDataToPostgreSQL
    {
        public void InicialDataToPostgreSQLLoad()
        {
            var dataUserTypes = new DataUserTypes();
            var dataUsers = new DataUsers();


            dataUserTypes.AddUserTypes();
            dataUsers.AddUsers();


        }
    }
}
