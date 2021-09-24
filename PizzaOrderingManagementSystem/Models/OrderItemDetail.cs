namespace PizzaOrderingManagementSystem.Models
{
    public class OrderItemDetail
    {
        public int OrderDetailsId { get; set; }
        public int ToppingId { get; set; }

        public virtual OrderDetail OrderDetails { get; set; }
        public virtual Topping Topping { get; set; }
    }
}