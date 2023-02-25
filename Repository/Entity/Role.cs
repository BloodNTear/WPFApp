using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Role
    {
        [Key]
        public string RoleName { get; set; }

        public virtual List<Permission> Pemissions { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
