using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourierService.DbContextModels.Postgre
{
   public class UsersType
    {
        public UsersType()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserType { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
