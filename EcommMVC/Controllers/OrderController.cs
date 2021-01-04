using System;
using System.Collections;
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


        // GET: /Orders/PlaceOrder
        public ActionResult PlaceOrder()
        {



            var check = true;
            string OrderId = "";

            while (check)
            {
                var guid = Guid.NewGuid().ToString();

                var checkOrderId = _context.Orders.ToList().Where(o =>
                    o.OrderId.Equals(guid));

                if (!checkOrderId.Any())
                {
                    check = false;
                    OrderId = guid;
                }

            }

            TempData["OrderId"] = OrderId;

            return View();
        }

        // POST: /Orders/PlaceOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PlaceOrder(Order order)
        {


            if (!ModelState.IsValid)
            {
                return View(order);
            }


            var TotalPayable = (double)TempData["totalPayable"];
            var cart = _context.Carts.ToList().Where(c => c.UserId == User.Identity.GetUserId());
            var orderDetails = (IEnumerable<OrderDetails>)TempData["orderList"];
            //var CurrentUser = _context.Users.SingleOrDefault(u => u.Id == User.Identity.GetUserId());


            //var Balance = CurrentUser.Wallet - TotalPayable;


            foreach (var item in orderDetails)
            {

                item.OrderId = order.OrderId;
                _context.OrderDetails.Add(item);


            }

            foreach (var item in cart)
            {
                _context.Carts.Remove(item);
            }


            _context.Orders.Add(order);



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