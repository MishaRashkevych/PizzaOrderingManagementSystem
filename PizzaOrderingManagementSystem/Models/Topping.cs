using System.Collections.Generic;

namespace PizzaOrderingManagementSystem.Models
{
    public class Topping
    {
        public Topping()
        {
            OrderItemDetails = new HashSet<OrderItemDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<OrderItemDetail> OrderItemDetails { get; set; }
    }
}