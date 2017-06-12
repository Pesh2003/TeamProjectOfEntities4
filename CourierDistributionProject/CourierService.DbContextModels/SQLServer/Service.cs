using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierService.DbContextModels.SQLServer
{
    public class Service
    {
        public int Id { get; set; }

        [Required]        
        public virtual ServiceOption ServiceOption{ get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Details { get; set; }

        public bool IsTaken { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]        
        public virtual City City { get; set; }

        [Required]
        public int OfficeId { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public int UserId { get; set; }

        public int UserFixerId { get; set; }
        
    }
}
