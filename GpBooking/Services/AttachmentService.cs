using System;
using System.IO;
using System.Web;

namespace GpBooking.Services
{
    public static class AttachmentService
    {
        public static bool CheckFileAbleToSave(HttpPostedFileBase img)
        {
            //Checking file is available to save.  
            string extension = Path.GetExtension(img?.FileName);
            if (extension != null && (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" ||
                                      extension.ToLower() == ".jpeg" || extension.ToLower() == ".pdf"))
            {
                return true;
            }

            return false;
        }

        public static string SaveImg(HttpPostedFileBase attachment, string serverPath, string folder)
        {
            string extension = Path.GetExtension(attachment.FileName);
            string path = serverPath;
            string name =
                $"{Path.GetFileNameWithoutExtension(attachment.FileName)}{DateTime.Now.ToLongDateString()}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
            string attachmentName = $"{name}{extension}";
            string fileName = Path.Combine(path, attachmentName);
            attachment.SaveAs(fileName);
            return $"~/Attachments/{folder}/{attachmentName}";
        }
    }
}
