using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.MVCUI.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            List<Genre> genres = GenreManager.Load();
            return View(genres);
        }

        [ChildActionOnly]
        public ActionResult Sidebar()
        {
            var genres = GenreManager.Load();
            return PartialView(genres);
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Details";
            Genre genre = GenreManager.LoadById(id);
            return View(genre);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            Genre genre = new Genre();
            return View(genre);
        }

        // POST: Genre/Create
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            try
            {
                // TODO: Add insert logic here
                GenreManager.Insert(genre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            Genre genre = GenreManager.LoadById(id);
            return View(genre);
        }

        // POST: Genre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Genre genre)
        {
            try
            {
                // TODO: Add update logic here
                GenreManager.Update(genre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            Genre genre = GenreManager.LoadById(id);
            return View(genre);
        }

        // POST: Genre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Genre genre)
        {
            try
            {
                // TODO: Add delete logic here
                GenreManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
