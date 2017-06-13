using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContextModels.SQLite
{
    public class Category
    {
        private ICollection<Brand> brands;
        private ICollection<Vehicle> vehicles;

        public Category()
        {
            this.brands = new HashSet<Brand>();
            this.vehicles = new HashSet<Vehicle>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string CategoryName { get; set; }

        public virtual ICollection<Brand> Brands
        {
            get
            {
                return this.brands;
            }
            set
            {
                this.brands = value;
            }
        }

        public virtual ICollection<Vehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
            set
            {
                this.vehicles = value;
            }
        }
    }
}
