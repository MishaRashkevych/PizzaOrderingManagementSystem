using System.Collections.Generic;

namespace PizzaOrderingManagementSystem.Models
{
    public class Pizza
    {
        public Pizza()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Crust { get; set; }
        public string Speciality { get; set; }
        public bool IsVeg { get; set; }
        public string Picture { get; set; }
        public string Details { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}