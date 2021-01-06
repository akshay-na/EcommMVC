using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

            var myOrders = _context.OrderDetails.ToList().Where(o => o.UserId == User.Identity.GetUserId());

            return View(myOrders);
        }


        // GET: /Order/PlaceOrder
        public ActionResult PlaceOrder()
        {



            var check = true;
            string OrderId = "";
            var userId = User.Identity.GetUserId();
            var CurrentUser = _context.Users.FirstOrDefault(u => u.Id == userId);
            var cartItems = _context.Carts.ToList().Where(c => c.UserId == userId);
            while (check)
            {
                var guid = Guid.NewGuid().ToString();

                var checkOrderId = _context.Orders.ToList().Where(o =>
                    o.OrderId.Equals(guid));

                if (!checkOrderId.Any())
                {
                    check = false;
                    OrderId = guid;
                    Session["OrderId"] = guid;
                }

            }


            var order = new Order()
            {
                OrderId = OrderId,
                UserId = User.Identity.GetUserId(),
                Email = CurrentUser.Email,
                SaveInfo = true,

            };

            Session["cartList"] = cartItems;
            Session["WalletBalance"] = CurrentUser.Wallet;

            return View(order);
        }

        // POST: /Order/PlaceOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PlaceOrder(Order order)
        {


            if (!ModelState.IsValid)
            {
                return View(order);
            }

            var userId = User.Identity.GetUserId();
            var TotalPayable = (double)Session["totalPayable"];
            var CurrentUser = _context.Users.SingleOrDefault(u => u.Id == userId);
            var Balance = CurrentUser.Wallet - TotalPayable;

            _context.Orders.Add(order);

            if (Balance < 0.0)
            {
                return View(order);
            }

            var cart = _context.Carts.ToList().Where(c => c.UserId == userId);

            foreach (var item in cart)
            {
                _context.OrderDetails.Add(new OrderDetails()
                {
                    OrderId = order.OrderId,
                    ProductId = item.ItemId,
                    UserId = item.UserId,
                    ItemQuantity = item.ItemQuantity,
                    ItemName = item.ItemName,
                    TotalPrice = item.ItemPrice * item.ItemQuantity,
                    OrderStatus = "Order Placed",
                    DeliverStatus = false,
                });

                _context.Carts.Remove(item);
            }

            CurrentUser.Wallet = Balance;
            _context.Users.AddOrUpdate(CurrentUser);

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