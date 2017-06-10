using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContextModels.PostgreSQL
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
