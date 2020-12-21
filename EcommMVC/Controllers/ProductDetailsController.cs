using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommMVC.Models;

namespace EcommMVC.Controllers
{
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

    }
}