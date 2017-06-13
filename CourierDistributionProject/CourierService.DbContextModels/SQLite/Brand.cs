using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContextModels.SQLite
{
    public class Brand
    {
        private ICollection<Model> models;
        private ICollection<Vehicle> vehicles;

        public Brand()
        {
            this.models = new HashSet<Model>();
            this.vehicles = new HashSet<Vehicle>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string BrandName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Model> Models
        {
            get
            {
                return this.models;
            }
            set
            {
                this.models = value;
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
