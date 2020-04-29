using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public static class OrderManager
    {
        public static int Insert(out int id, int customerId, int userId, DateTime orderDate, DateTime shipDate)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder newrow = new tblOrder();

                    newrow.UserId = userId;
                    newrow.OrderDate = orderDate;
                    newrow.ShipDate = shipDate;
                    newrow.CustomerId = customerId;

                    //giving a new row the next id after existing one or if there is none id equals to 1
                    newrow.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(dt => dt.Id) + 1 : 1;

                    id = newrow.Id;

                    dc.tblOrders.Add(newrow);

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Order order)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, order.CustomerId, order.UserId, order.OrderDate, order.ShipDate);
                order.Id = id;
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
                    tblOrder deleterow = (from dt in dc.tblOrders
                                          where dt.Id == id
                                          select dt).FirstOrDefault();
                    dc.tblOrders.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(int id, int customerId, int userId, DateTime orderDate, DateTime shipDate)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder updaterow = (from dt in dc.tblOrders
                                          where dt.Id == id
                                          select dt).FirstOrDefault();


                    updaterow.UserId = userId;
                    updaterow.OrderDate = orderDate;
                    updaterow.ShipDate = shipDate;
                    updaterow.CustomerId = customerId;

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(Order order)
        {
            return Update(order.Id, order.CustomerId, order.UserId, order.OrderDate, order.ShipDate);
        }

        public static List<Order> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Order> orders = new List<Order>();
                    foreach (tblOrder dt in dc.tblOrders)
                    {
                        orders.Add(new Order
                        {
                            Id = dt.Id,
                            UserId = dt.UserId,
                            CustomerId = dt.CustomerId,
                            OrderDate = dt.OrderDate,
                            ShipDate = dt.ShipDate
                        });
                    }
                    return orders;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Order LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder row = (from dt in dc.tblOrders
                                    where dt.Id == id
                                    select dt).FirstOrDefault();

                    if (row != null)
                        return new Order
                        {
                            Id = row.Id,
                            CustomerId = row.CustomerId,
                            UserId = row.UserId,
                            OrderDate = row.OrderDate,
                            ShipDate = row.ShipDate
                        };
                    else
                        throw new Exception("Row was not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Order> LoadByCustomerId(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Order> results = new List<Order>();
                    var orders = (from dt in dc.tblOrders
                                  where dt.CustomerId == id
                                  select dt).ToList();

                    orders.ForEach(o => results.Add(new Order
                    {
                        Id = o.Id,
                        CustomerId = o.CustomerId,
                        UserId = o.UserId,
                        OrderDate = o.OrderDate,
                        ShipDate = o.ShipDate
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
