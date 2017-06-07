using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourierService.DbContextModels.SQLServer
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }      
        
        public virtual ICollection<Office> Offices { get; set; } 

        public virtual ICollection<Service> Services { get; set; }
                      
    }
}
