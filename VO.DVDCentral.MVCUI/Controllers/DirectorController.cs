﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.MVCUI.Models;

namespace VO.DVDCentral.MVCUI.Controllers
{
    public class DirectorController : Controller
    {
        // GET: Director
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Index";
                List<Director> directors = DirectorManager.Load();
                return View(directors);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // GET: Director/Details/5
        public ActionResult Details(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Details";
                Director director = DirectorManager.LoadById(id);
                return View(director);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // GET: Director/Create
        public ActionResult Create()
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Create";
                Director director = new Director();
                return View(director);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Director/Create
        [HttpPost]
        public ActionResult Create(Director director)
        {
            try
            {
                // TODO: Add insert logic here
                DirectorManager.Insert(director);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Director/Edit/5
        public ActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Edit";
                Director director = DirectorManager.LoadById(id);
                return View(director);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Director/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Director director)
        {
            try
            {
                // TODO: Add update logic here
                DirectorManager.Update(director);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Director/Delete/5
        public ActionResult Delete(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Delete";
                Director director = DirectorManager.LoadById(id);
                return View(director);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Director/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Director director)
        {
            try
            {
                // TODO: Add delete logic here
                DirectorManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
