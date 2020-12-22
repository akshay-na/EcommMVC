using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using EcommMVC.Models;
using Microsoft.AspNet.Identity;

namespace EcommMVC.Controllers
{
    [System.Web.Mvc.Authorize]
    public class CartController : Controller
    {
        private ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Cart
        public ActionResult Index()
        {

            var cart = _context.Carts.ToList().Where(c => c.UserId == User.Identity.GetUserId());
            
            return View(cart);
        }



        // POST: /Cart/AddtoCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddtoCart(Cart cart)
        {



            return RedirectToAction("Index", "ProductDetails");

        }

        // POST: /Cart/RemoveFromCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveFromCart(Cart cart)
        {



            return RedirectToAction("Index", "Cart");

        }

    }
}