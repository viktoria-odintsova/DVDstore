﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.MVCUI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user, string returnurl)
        {
            try
            {
                if (UserManager.Login(user))
                {
                    Session["user"] = user;
                    return Redirect(returnurl);
                }
                ViewBag.Message = "Sorry. Could not login";
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return View();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            User user = new User();
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                UserManager.Insert(user);
                return RedirectToAction("Index", "Movie");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
