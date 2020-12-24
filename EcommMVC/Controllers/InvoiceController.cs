using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EcommMVC.Models;
using EcommMVC.ViewModels;

namespace EcommMVC.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {

        // GET: Invoice/GenerateInvoice
        public  ActionResult GenerateInvoice(ListOfOrderDetails orderList)
        {

            if (orderList.OrderDetail == null)
            {
                return Content("Something Went Wrong, Please Try Again");
            }


            return View(orderList);
        }
    }
}