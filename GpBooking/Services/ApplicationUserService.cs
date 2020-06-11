using System.Web;
using GpBooking.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GpBooking.Services
{
    public static class ApplicationUserService
    {
        public static ApplicationUser GetUser()
        {
            return HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(HttpContext.Current.User.Identity.GetUserId());
        }

        public static string GetUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
    }
}
