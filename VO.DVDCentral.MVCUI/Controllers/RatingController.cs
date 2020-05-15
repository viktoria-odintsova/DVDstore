using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.MVCUI.Models;

namespace VO.DVDCentral.MVCUI.Controllers
{
    public class RatingController : Controller
    {
        List<Rating> ratings;

        #region "Pre-WebAPI"
        // GET: Rating
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Index";
                ratings = RatingManager.Load();
                return View(ratings);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

            // GET: Rating/Details/5
            public ActionResult Details(int id)
            {
                if (Authenticate.IsAuthenticated())
                {
                    ViewBag.Title = "Details";
                    Rating rating = RatingManager.LoadById(id);
                    return View(rating);
                }
                else
                {
                    return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
                }
            }

                // GET: Rating/Create
                public ActionResult Create()
                {
                    if (Authenticate.IsAuthenticated())
                    {
                        ViewBag.Title = "Create";
                        Rating rating = new Rating();
                        return View(rating);
                    }
                    else
                    {
                        return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
                    }
                }

        // POST: Rating/Create
        [HttpPost]
        public ActionResult Create(Rating rating)
        {
            try
            {
                // TODO: Add insert logic here
                RatingManager.Insert(rating);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Edit";
                Rating rating = RatingManager.LoadById(id);
                return View(rating);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Rating rating)
        {
            try
            {
                // TODO: Add update logic here
                RatingManager.Update(rating);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Delete/5
        public ActionResult Delete(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Delete";
                Rating rating = RatingManager.LoadById(id);
                return View(rating);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Rating/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Rating rating)
        {
            try
            {
                // TODO: Add delete logic here
                RatingManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region "WebAPI"
        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44348//api/");
            return client;
        }

        public ActionResult Get()
        {
            HttpClient client = InitializeClient();

            //do the actual call to the WebAPI
            HttpResponseMessage response = client.GetAsync("Rating").Result;

            //parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //parse the result into generic objects
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);

            //parse the items into a list of rating
            List<Rating> ratings = items.ToObject<List<Rating>>();

            ViewBag.Source = "Get";
            return View("Index", ratings);
        }

        public ActionResult GetOne(int id)
        {
            HttpClient client = InitializeClient();

            //do the actual call to the WebAPI
            HttpResponseMessage response = client.GetAsync("Rating/" + id).Result;

            //parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //parse the result into generic objects
            Rating rating = JsonConvert.DeserializeObject<Rating>(result);

            return View("Details", rating);
        }

        public ActionResult Insert()
        {
            HttpClient client = InitializeClient();

            Rating rating = new Rating();
            return View("Create", rating);

        }

        [HttpPost]
        public ActionResult Insert(Rating rating)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Rating", rating).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create", rating);
            }
        }

        public ActionResult Update(int id)
        {
            HttpClient client = InitializeClient();

            HttpResponseMessage response = client.GetAsync("Rating/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Rating rating = JsonConvert.DeserializeObject<Rating>(result);
            return View("Edit", rating);
        }

        [HttpPost]
        public ActionResult Update(int id, Rating rating)
        {
            try
            {
                HttpClient client = InitializeClient();

                HttpResponseMessage response = client.PutAsJsonAsync("Rating/" + id, rating).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Edit", rating);
            }
        }

        public ActionResult Remove(int id)
        {
            HttpClient client = InitializeClient();
            HttpResponseMessage response = client.GetAsync("Rating/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Rating rating = JsonConvert.DeserializeObject<Rating>(result);
            return View("Delete", rating);

        }

        [HttpPost]
        public ActionResult Remove(int id, Rating rating)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.DeleteAsync("Rating/" + id).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Delete", rating);
            }

        }
        #endregion
    }
}
