using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierService.DbContextModels.SQLServer
{
    public class ServiceOption
    {
        public int Id { get; set; }

        [Required]             
        public virtual ServicesType ServicesType { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
