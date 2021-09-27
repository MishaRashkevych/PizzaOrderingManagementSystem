using Microsoft.EntityFrameworkCore;
using PizzaOrderingManagementSystem.Models;
using PizzaOrderingManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingManagementSystem.Services
{
    public class CartRepo
    {
        private readonly int? _orderId;
        private readonly PizzaContext _context;
        readonly DbSet<Order> _dbSet;

        public CartRepo(PizzaContext context, int? orderId)
        {
            _orderId = orderId;
            _context = context;
            _dbSet = _context.Set<Order>();
        }

        public IEnumerable<CartItem> Get()
        {
            var cartItems = new List<CartItem>();
            var order = _dbSet.Where(o => o.Id == _orderId)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Pizza).FirstOrDefault();

            
            foreach (var item in order.OrderDetails)
            {
                var orderDetails = _context.Orderdetails.Where(o => o.PizzaId == item.Pizza.Id).Include(o=>o.OrderItemDetails).FirstOrDefault();
                foreach (var item1 in orderDetails.OrderItemDetails)
                {
                    var toppings = _context.Toppings.Where(t => t.Id == item1.ToppingId).ToList();
                    cartItems.Add(new CartItem(item.Pizza, toppings, item.Id));
                }
            }
            return cartItems;
        }

        public double? GetTotalSum()
        {
            var cartItems = new List<CartItem>();
            var order = _dbSet.Where(o => o.Id == _orderId)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Pizza).FirstOrDefault();
            double? sum = 0;
            foreach (var item in order.OrderDetails)
            {
                sum += item.Pizza.Price;
                var orderDetails = _context.Orderdetails.Where(o => o.PizzaId == item.Pizza.Id).Include(o => o.OrderItemDetails).FirstOrDefault();

                foreach (var topping in orderDetails.OrderItemDetails)
                {
                    double? toppingsSum = _context.Toppings.Where(t => t.Id == topping.ToppingId).Sum(t=>t.Price);
                    sum += toppingsSum;
                }
            }
            order.Total = sum;
            return sum;
        }

        public void DeleteOrder()
        {
            var order = _dbSet.Where(o => o.Id == _orderId)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.OrderItemDetails).FirstOrDefault();
            _dbSet.Remove(order);
            _context.SaveChanges();
        }

        public void DeleteItem(CartItem cartItem)
        {
            var orderDetail = _context.Orderdetails.Where(p => p.PizzaId == cartItem.Pizza.Id).Include(oi=>oi.OrderItemDetails).FirstOrDefault();
            _context.Orderdetails.Remove(orderDetail);
            _context.SaveChanges();
        }
    }
}
