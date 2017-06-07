using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourierService.DbContextModels.SQLServer
{
    public class ServicesType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]        
        public string ServiceType { get; set; }

        public virtual ICollection<ServiceOption> ServiceOptions { get; set; }
    }
}
