using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierService.DbContextModels.SQLServer
{
    public class Office
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }
        
        [Required]       
        public virtual City City{ get; set; }
    }
}
