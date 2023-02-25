using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailID { get; set; }
        public int Quantity { get; set; }

        //Relationship
        public virtual Order Order { get; set; }
        public Guid OrderID { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductID { get; set; }
    }
}
