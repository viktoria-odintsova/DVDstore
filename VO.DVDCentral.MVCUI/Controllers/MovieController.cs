using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.MVCUI.ViewModels;

namespace VO.DVDCentral.MVCUI.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            var movies = MovieManager.Load();
            return View(movies);
        }

        public ActionResult Browse(int id, string description)
        {

            ViewBag.Title = description;
            var movies = MovieManager.Load(id);
            return View("Index", movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Details";
            var movie = MovieManager.LoadById(id);
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            MovieGenresDirectorsRatingsFormats mdf = new MovieGenresDirectorsRatingsFormats();

            mdf.Movie = new DVDCentral.BL.Models.Movie();
            mdf.FormatList = FormatManager.Load();
            mdf.RatingList = RatingManager.Load();
            mdf.DirectorList = DirectorManager.Load();
            mdf.GenreList = GenreManager.Load();

            return View(mdf);
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(MovieGenresDirectorsRatingsFormats mdf)
        {
            try
            {
                if(mdf.File != null)
                {
                    mdf.Movie.ImagePath = mdf.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(mdf.File.FileName));

                    if (!System.IO.File.Exists(target))
                    {
                        mdf.File.SaveAs(target);
                        ViewBag.Message = "File uploaded successfully...";
                    }
                    else
                    {
                        ViewBag.Message = "File already exists...";
                    }
                }

                // TODO: Add insert logic here
                MovieManager.Insert(mdf.Movie);
                mdf.GenreIds.ToList().ForEach(g => MovieGenreManager.Add(mdf.Movie.Id, g));
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(mdf);
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";

            MovieGenresDirectorsRatingsFormats mgdrf = new MovieGenresDirectorsRatingsFormats();

            mgdrf.Movie = MovieManager.LoadById(id);
            mgdrf.RatingList = RatingManager.Load();
            mgdrf.FormatList = FormatManager.Load();
            mgdrf.GenreList = GenreManager.Load();
            mgdrf.DirectorList = DirectorManager.Load();

            mgdrf.Movie.Genres = MovieManager.LoadGenres(id);
            mgdrf.GenreIds = mgdrf.Movie.Genres.Select(g => g.Id);
            Session["genreids"] = mgdrf.GenreIds;


            return View(mgdrf);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieGenresDirectorsRatingsFormats mdf)
        {
            try
            {
                if (mdf.File != null)
                {
                    mdf.Movie.ImagePath = mdf.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(mdf.File.FileName));

                    if (!System.IO.File.Exists(target))
                    {
                        mdf.File.SaveAs(target);
                        ViewBag.Message = "File uploaded successfully...";
                    }
                    else
                    {
                        ViewBag.Message = "File already exists...";
                    }
                }

                IEnumerable<int> oldgenreids = new List<int>();
                if (Session["genreids"] != null)
                {
                    oldgenreids = (IEnumerable<int>)Session["genreids"];
                }

                IEnumerable<int> newgenreids = new List<int>();
                if (mdf.GenreIds != null)
                {
                    newgenreids = mdf.GenreIds;
                }

                IEnumerable<int> deletes = oldgenreids.Except(newgenreids);
                IEnumerable<int> adds = newgenreids.Except(oldgenreids);

                deletes.ToList().ForEach(d => MovieGenreManager.Delete(id, d));
                adds.ToList().ForEach(a => MovieGenreManager.Add(id, a));

                // TODO: Add update logic here
                MovieManager.Update(mdf.Movie);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(mdf);
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
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
                movie.Genres = MovieManager.LoadGenres(id);
                movie.Genres.ForEach(g => MovieGenreManager.Delete(id, g.Id));
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
