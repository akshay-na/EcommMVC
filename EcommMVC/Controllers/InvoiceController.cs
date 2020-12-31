using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EcommMVC.Models;

namespace EcommMVC.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {

        private ApplicationDbContext _context;

        public InvoiceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Invoice/GenerateInvoice
        public  ActionResult GenerateInvoice()
        {

            var orderList = (IEnumerable<OrderDetails>)TempData["orderList"];

            if (orderList == null)
            {
                return HttpNotFound();
            }


            return View(orderList);
        }
    }
}