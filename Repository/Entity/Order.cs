using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        //RelationShip
        public User Customer { get; set; }
        public string UserName { get; set; }
    }
}
