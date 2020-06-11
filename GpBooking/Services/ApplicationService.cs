using System;
using System.Configuration;

namespace GpBooking.Services
{
    public static class ApplicationService
    {
        public static string ReadFromWebConfig(string nameValue)
        {
            string result = "";
            try
            {
                result = ConfigurationManager.AppSettings[nameValue];
            }

            catch (Exception)
            {
                // ignored
            }

            return result;
        }
    }
}