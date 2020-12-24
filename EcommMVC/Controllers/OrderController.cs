using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EcommMVC.Models;
using Microsoft.AspNet.Identity;

namespace EcommMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        private ApplicationDbContext _context;

        public OrderController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: OrderDetails
        public ActionResult Index()
        {

           var myOrders =  _context.OrderDetails.ToList().Where(o => o.UserId == User.Identity.GetUserId());
            
            return View(myOrders);
        }

        // POST: /Orders/PleaseOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PlaceOrder(List<OrderDetails> orders)
        {

            var TotalAmount = 0.00;

            foreach (var order in orders)
            {
                _context.OrderDetails.Add(order);
                TotalAmount = TotalAmount + order.TotalPrice;
            }

            UpdateDatabase();


            return RedirectToAction("Index", "ProductDetails");


            
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