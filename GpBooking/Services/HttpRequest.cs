namespace GpBooking.Services
{
    public static class HttpRequest
    {
        public static string GetClientIp()
        {
            try
            {
                System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
                string ipAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!string.IsNullOrEmpty(ipAddress))
                {
                    string[] addresses = ipAddress.Split(',');
                    if (addresses.Length != 0)
                    {
                        return addresses[0];
                    }
                }

                return request.ServerVariables["REMOTE_ADDR"];
            }
            catch
            {
                return "";
            }

        }
    }
}