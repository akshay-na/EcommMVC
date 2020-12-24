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
    [Authorize]
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


        // POST: /Cart/AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddToCart(Cart cart)
        {


            if (!ModelState.IsValid)
            {
                return View(cart);
            }

            _context.Carts.Add(cart);

            UpdateDatabase();

            return RedirectToAction("Index", "ProductDetails");

        }

        // POST: /Cart/RemoveFromCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveFromCart(int cartId)
        {

            var RemoveItem = _context.Carts.SingleOrDefault(c => c.CartId == cartId);
            
            if (!ModelState.IsValid)
            {
                return View(cartId);
            }

            _context.Carts.Remove(RemoveItem);

            UpdateDatabase();


            return RedirectToAction("Index", "Cart");

        }

        // GET: /Cart/ChangeItemQuantity
        public async Task<ActionResult> ChangeItemQuantity(int cartId, int itemQuantity)
        {

            var ChangeQuantity = _context.Carts.SingleOrDefault(c => c.CartId == cartId);

            if (!ModelState.IsValid)
            {
                return Content("Something Went Wrong! PLease Try Again");
            }

            if (ChangeQuantity != null)
            {
                ChangeQuantity.ItemQuantity = itemQuantity;
                UpdateDatabase();
            }


            return RedirectToAction("Index", "Cart");
        }



        // A Exception Handling Method for Updating the database records.
        private int UpdateDatabase()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return 0;
        }

    }
}