using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderingManagementSystem.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        public string UEmail { get; set; }
        public double? Total { get; set; }
        public double? DeliveryCharge { get; set; }
        public string Status { get; set; }

        public virtual Register UEmailNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
