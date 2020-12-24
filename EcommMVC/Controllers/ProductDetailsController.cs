using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EcommMVC.Models;
using Microsoft.AspNet.Identity;

namespace EcommMVC.Controllers
{
    [AllowAnonymous]
    public class ProductDetailsController : Controller
    {

        private ApplicationDbContext _context;

        public ProductDetailsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ProductDetails
        public ViewResult Index()
        {

            var Products = _context.Product;

            return View(Products);
        }

        //GET: /Products/MyProducts
        [Authorize(Roles = "Vendor")]
        public ActionResult MyProducts()
        {

            var myProduct = _context.Product.ToList().Where(p => p.VendorId == User.Identity.GetUserId());

            return View(myProduct);

        }



        public ActionResult Details(int id)

        {

            var Product = _context.Product.SingleOrDefault(c => c.ProductId == id);

            if (Product == null)
                return HttpNotFound();


           
            
            return View(Product);
        }

        // GET: /Products/AddProducts
        [Authorize(Roles = "Vendor")]
        public ActionResult AddProducts()
        {

            return View();

        }
        
        // POST: /Products/AddProducts
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<ActionResult> AddProducts(ProductDetails product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.Product.Add(product);

            _context.SaveChanges();

            UpdateDatabase();
            
            return RedirectToAction("Index", "Home");

        }
        
        //POST: /Products/RemoveProducts
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<ActionResult> RemoveProducts(int productId)
        {

            var RemoveItem = _context.Product.SingleOrDefault(p => p.ProductId == productId);

            if (!ModelState.IsValid)
            {
                return View(productId);
            }

            _context.Product.Remove(RemoveItem);

            UpdateDatabase();

            return RedirectToAction("MyProducts", "ProductDetails");

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