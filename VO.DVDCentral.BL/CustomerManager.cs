using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public static class CustomerManager
    {
        public static int Insert(out int id, int userId, string firstName, string lastName, string address, 
                                string city, string state, string zip, string phone)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer newrow = new tblCustomer();

                    newrow.UserId = userId;
                    newrow.FirstName = firstName;
                    newrow.LastName = lastName;
                    newrow.Address = address;
                    newrow.City = city;
                    newrow.State = state;
                    newrow.ZIP = zip;
                    newrow.Phone = phone;

                    //giving a new row the next id after existing one or if there is none id equals to 1
                    newrow.Id = dc.tblCustomers.Any() ? dc.tblCustomers.Max(dt => dt.Id) + 1 : 1;

                    id = newrow.Id;

                    dc.tblCustomers.Add(newrow);

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Customer customer)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, customer.UserId, customer.FirstName, customer.LastName, customer.Address, 
                                customer.City, customer.State, customer.Zip, customer.Phone);
                customer.Id = id;
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
                    tblCustomer deleterow = (from dt in dc.tblCustomers
                                          where dt.Id == id
                                          select dt).FirstOrDefault();
                    dc.tblCustomers.Remove(deleterow);
                    return dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(int id, int userId, string firstName, string lastName, string address, string city, 
                        string state, string zip, string phone)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer updaterow = (from dt in dc.tblCustomers
                                          where dt.Id == id
                                          select dt).FirstOrDefault();

                    updaterow.UserId = userId;
                    updaterow.FirstName = firstName;
                    updaterow.LastName = lastName;
                    updaterow.Address = address;
                    updaterow.City = city;
                    updaterow.State = state;
                    updaterow.ZIP = zip;
                    updaterow.Phone = phone;

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(Customer customer)
        {
            return Update(customer.Id, customer.UserId, customer.FirstName, customer.LastName, customer.Address, 
                        customer.City, customer.State, customer.Zip, customer.Phone);
        }

        public static List<Customer> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Customer> customers = new List<Customer>();
                    foreach (tblCustomer dt in dc.tblCustomers)
                    {
                        customers.Add(new Customer
                        {
                            Id = dt.Id,
                            UserId = dt.UserId,
                            FirstName = dt.FirstName,
                            LastName = dt.LastName,
                            Address = dt.Address,
                            City = dt.City,
                            State = dt.State,
                            Zip = dt.ZIP,
                            Phone = dt.Phone
                        });
                    }
                    return customers;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Customer LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer row = (from dt in dc.tblCustomers
                                    where dt.Id == id
                                    select dt).FirstOrDefault();

                    if (row != null)
                        return new Customer { Id = row.Id, FirstName = row.FirstName, LastName = row.LastName, Address = row.Address,
                                            City = row.City, State = row.State, Zip = row.ZIP, Phone = row.Phone, UserId = row.UserId};
                    else
                        throw new Exception("Row was not found");                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
