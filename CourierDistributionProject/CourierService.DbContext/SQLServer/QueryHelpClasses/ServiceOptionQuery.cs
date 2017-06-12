using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLServer.QueryHelpClasses
{
    public class ServiceOptionQuery
    { 
        public int ServOptionId { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public double TimeDuration { get; set; }

        public string ServiceType { get; set; }                                    
    }
}
