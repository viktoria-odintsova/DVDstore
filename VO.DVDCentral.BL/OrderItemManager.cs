using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public static class OrderItemManager
    {
        public static int Insert(out int id, int orderId, int movieId, int quantity, double cost)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem newrow = new tblOrderItem();

                    newrow.OrderId = orderId;
                    newrow.MovieId = movieId;
                    newrow.Quantity = quantity;
                    newrow.Cost = cost;

                    //giving a new row the next id after existing one or if there is none id equals to 1
                    newrow.Id = dc.tblOrderItems.Any() ? dc.tblOrderItems.Max(dt => dt.Id) + 1 : 1;

                    id = newrow.Id;

                    dc.tblOrderItems.Add(newrow);

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(OrderItem orderItem)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, orderItem.OrderId, orderItem.MovieId, orderItem.Quantity, orderItem.Cost);
                orderItem.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Delete(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem deleterow = (from dt in dc.tblOrderItems
                                          where dt.Id == id
                                          select dt).FirstOrDefault();
                    dc.tblOrderItems.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(int id, int orderId, int movieId, int quantity, double cost)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem updaterow = (from dt in dc.tblOrderItems
                                          where dt.Id == id
                                          select dt).FirstOrDefault();

                    updaterow.OrderId = orderId;
                    updaterow.MovieId = movieId;
                    updaterow.Quantity = quantity;
                    updaterow.Cost = cost;

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(OrderItem orderItem)
        {
            return Update(orderItem.Id, orderItem.OrderId, orderItem.MovieId, orderItem.Quantity, orderItem.Cost);
        }

        public static List<OrderItem> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<OrderItem> orderItems = new List<OrderItem>();
                    foreach (tblOrderItem dt in dc.tblOrderItems)
                    {
                        orderItems.Add(new OrderItem
                        {
                            Id = dt.Id,
                            OrderId = dt.OrderId,
                            MovieId = dt.MovieId,
                            Quantity = dt.Quantity,
                            Cost = dt.Cost
                        });
                    }
                    return orderItems;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static OrderItem LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem row = (from dt in dc.tblOrderItems
                                    where dt.Id == id
                                    select dt).FirstOrDefault();

                    if (row != null)
                        return new OrderItem { Id = row.Id,  OrderId = row.OrderId, MovieId = row.MovieId, Cost = row.Cost, Quantity = row.Quantity};
                    else
                        throw new Exception("Row was not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<OrderItem> LoadByOrderId(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<OrderItem> results = new List<OrderItem>();
                    var orderItems = (from dt in dc.tblOrderItems
                                  where dt.OrderId == id
                                  select dt).ToList();

                    orderItems.ForEach(oi => results.Add(new OrderItem
                    {
                        Id = oi.Id,
                        OrderId = oi.OrderId,
                        MovieId = oi.MovieId,
                        Cost = oi.Cost,
                        Quantity = oi.Quantity
                    }));

                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
