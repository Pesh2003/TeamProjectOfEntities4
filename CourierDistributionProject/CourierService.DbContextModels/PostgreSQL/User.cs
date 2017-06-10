﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierService.DbContextModels.PostgreSQL
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }


        public int UserTypeId { get; set; }


        public virtual UsersType UserType { get; set; }


    }
}
