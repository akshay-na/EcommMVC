using EcommMVC.Models;
using System.Web.Mvc;

namespace EcommMVC.Controllers
{
  public class CartController : Controller
  {

    // GET: Cart/Random
    public ActionResult Random()
    {

      Cart cart = new Cart(1, 1, 2, "Example", 5, 100);

      return View(cart);

    }


  }
}

