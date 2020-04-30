﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.MVCUI.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> movies = MovieManager.Load();
            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = MovieManager.LoadById(id);
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            Movie movie = new Movie();
            return View(movie);
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                // TODO: Add insert logic here
                MovieManager.Insert(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movie = MovieManager.LoadById(id);
            return View(movie);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                // TODO: Add update logic here
                MovieManager.Insert(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = MovieManager.LoadById(id);
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                // TODO: Add delete logic here
                MovieManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
