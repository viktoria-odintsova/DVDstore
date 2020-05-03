using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.MVCUI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            List<Order> orders = OrderManager.Load();
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Details";
            Order order = OrderManager.LoadById(id);
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            Order order = new Order();
            return View(order);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                // TODO: Add insert logic here
                OrderManager.Insert(order);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            Order order = OrderManager.LoadById(id);
            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                // TODO: Add update logic here
                OrderManager.Update(order);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            Order order = OrderManager.LoadById(id);
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                OrderManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
