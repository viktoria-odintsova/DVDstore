using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.BL
{
    public static class ShoppingCartManager
    {
        public static void Checkout(ShoppingCart cart, User user)
        {
            Order order = new Order();
            order.CustomerId = 0;
            order.OrderDate = DateTime.Now;
            order.ShipDate = DateTime.Now;
            order.UserId = user.Id;
            OrderManager.Insert(order);

            foreach(Movie movie in cart.Items)
            {
                OrderItem item = new OrderItem();
                item.MovieId = movie.Id;
                item.OrderId = order.Id;
                item.Quantity = 1;
                item.Cost = movie.Cost;
                OrderItemManager.Insert(item);
            }
            cart.Checkout();
        }

        public static void Add(ShoppingCart cart, Movie movie)
        {
            cart.Add(movie);
        }

        public static void Remove(ShoppingCart cart, Movie movie)
        {
            cart.Remove(movie);
        }
    }
}
