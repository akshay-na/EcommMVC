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


        public ActionResult Details(int id)

        {

            var Product = _context.Product.SingleOrDefault(c => c.ProductId == id);

            if (Product == null)
                return HttpNotFound();

            return View(Product);
        }

        // GET: /Manage/AddProducts
        public ActionResult AddProducts()
        {

            return View();

        }

        // POST: /Manage/AddProducts
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddProducts(ProductDetails product)
        {

            

            if (!ModelState.IsValid)
            {
                return View(product);
            }


               _context.Product.Add(product);

               



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
            
            return RedirectToAction("Index", "Home");

        }

    }
}