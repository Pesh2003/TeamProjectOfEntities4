﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierService.DbContextModels.SQLServer
{
    public class ServiceOption
    {
        public ServiceOption()
        {
            this.Services = new HashSet<Service>();
        }
        public int Id { get; set; }

        [Required]
        public int ServicesTypeId { get; set; }

        public virtual ServicesType ServicesType { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public double TimeDuration { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
