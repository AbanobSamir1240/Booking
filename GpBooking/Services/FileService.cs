using System.IO;

namespace GpBooking.Services
{
    public static class FileService
    {
        public static string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                // Read entire text file content in one string  
                return File.ReadAllText(path);
            }

            return "";
        }
    }
}