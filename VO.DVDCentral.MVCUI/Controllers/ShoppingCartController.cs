using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.MVCUI.Models;

namespace VO.DVDCentral.MVCUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;

        // GET: ShoppingCart
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Shopping Cart";
                GetShoppingCart();
                return View(cart);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        private void GetShoppingCart()
        {
            if (Session["cart"] == null)
            {
                cart = new ShoppingCart();
            }
            else
            {
                cart = (ShoppingCart)Session["cart"];
            }
        }

        [ChildActionOnly]
        public ActionResult CartDisplay()
        {
            GetShoppingCart();
            return PartialView(cart);
        }

        public ActionResult RemoveFromCart(int id)
        {
            GetShoppingCart();
            DVDCentral.BL.Models.Movie movie = cart.Items.FirstOrDefault(i => i.Id == id);
            ShoppingCartManager.Remove(cart, movie);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        public ActionResult AddToCart(int id)
        {
            GetShoppingCart();
            Movie movie = MovieManager.LoadById(id);
            ShoppingCartManager.Add(cart, movie);
            Session["cart"] = cart;
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Checkout()
        {
            GetShoppingCart();
            User user = (User)Session["user"];
            ShoppingCartManager.Checkout(cart, user);
            return View();
        }
    }
}