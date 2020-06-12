using System.Web.Mvc;

namespace GpBooking.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {
            return View("Error");
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
