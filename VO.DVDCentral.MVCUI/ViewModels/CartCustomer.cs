using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.MVCUI.ViewModels
{
    public class CartCustomer
    {
        public ShoppingCart Cart { get; set; }
        public List<Customer> Customers { get; set; }
        public int CustomerId { get; set; }
    }
}