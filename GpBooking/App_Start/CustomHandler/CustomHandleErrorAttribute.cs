using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Web.Mvc;
using GpBooking.Models;
using GpBooking.Services;

namespace GpBooking.CustomHandler
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var otherInfo = string.Empty;
            var ip = HttpRequest.GetClientIp();
            try
            {
                var exception = filterContext.Exception;
                if (exception != null)
                {
                    while (exception.InnerException != null) exception = exception.InnerException;
                    otherInfo = "Message: " + exception.Message + " StackTrace :" + exception.StackTrace +
                                " Sourcec: " + exception.Source;
                }

                if (exception == null) return;
                using (var db = new ApplicationDbContext())
                {
                    db.ApplicationLogs.Add(new ApplicationLog()
                    {
                        CreatedByUser = ApplicationUserService.GetUserId(),
                        Data = $"Controller: {filterContext.Controller}",
                        Description = otherInfo,
                        Ip = ip != "::1" ? ip : "127.0.0.1",
                        Title = exception.Message ?? "",
                        Url = $"StackTrace: {exception.StackTrace}",
                        Id = 0,

                    });
                    db.SaveChanges();
                }

            }


            catch (DbEntityValidationException e)
            {
                StringBuilder temp = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    temp.Append(
                        $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        temp.Append($"- Property: {ve.PropertyName} , Error: {ve.ErrorMessage} ");
                    }
                }

                using (var db = new ApplicationDbContext())
                {
                    db.ApplicationLogs.Add(new ApplicationLog()
                    {
                        CreatedByUser = ApplicationUserService.GetUserId(),
                        Data = $"Controller: {filterContext.Controller}",
                        Description = temp.ToString(),
                        Ip = ip != "::1" ? ip : "127.0.0.1",
                        Title = e.Message ?? "",
                        Url = $"StackTrace: {e.StackTrace}",
                        Id = 0,

                    });
                    db.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                while (exception.InnerException != null) exception = exception.InnerException;
                otherInfo = "Message: " + exception.Message + " StackTrace :" + exception.StackTrace +
                            " Sourcec: " + exception.Source;


                if (exception == null) return;
                using (var db = new ApplicationDbContext())
                {
                    db.ApplicationLogs.Add(new ApplicationLog()
                    {
                        CreatedByUser = ApplicationUserService.GetUserId(),
                        Data = $"Controller: {filterContext.Controller}",
                        Description = otherInfo,
                        Ip = ip != "::1" ? ip : "127.0.0.1",
                        Title = exception.Message ?? "",
                        Url = $"StackTrace: {exception.StackTrace}",
                        Id = 0,

                    });
                    db.SaveChanges();
                }
            }

            base.OnException(filterContext);
        }
    }
}
