public partial class Pizza
    {
        public Pizza()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Crust {get;set;}
        public bool? Veg {get;set;}
        public bool? NonVeg {get;set;}

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }