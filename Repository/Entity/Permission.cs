using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Permission
    {
        [Key]
        public Guid PermissionID { get; set; }
        public string PermissionName { get; set; }
        public string RoleName { get; set; }
        public virtual Role Role { get; set; }
    }
}
