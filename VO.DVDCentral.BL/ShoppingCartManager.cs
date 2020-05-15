using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public static class ShoppingCartManager
    {
        public static void Checkout(ShoppingCart cart, User user, int customerId)
        {
            Order order = new Order();
            order.CustomerId = customerId;
            order.OrderDate = DateTime.Now;
            order.ShipDate = DateTime.Now;
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblUser result = (from dt in dc.tblUsers
                                  where user.UserId == dt.UserId
                                  select dt).FirstOrDefault();
                order.UserId = result.Id;

                tblCustomer customer = (from dt in dc.tblCustomers
                                        where order.UserId == dt.UserId
                                        select dt).FirstOrDefault();
                order.CustomerId = customer.Id;
            }

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
