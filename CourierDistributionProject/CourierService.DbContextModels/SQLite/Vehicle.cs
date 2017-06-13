using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContextModels.SQLite
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        [Required]
        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        [DefaultValue(0)]
        public int IsTaken { get; set; }
    }
}
