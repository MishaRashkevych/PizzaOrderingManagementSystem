using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderingManagementSystem.Models
{
    public partial class Register
    {
        public int RegisterID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }

    }
}