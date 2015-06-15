using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ProjectASP.NET.Models
{
    public class FileUploadService
    {
        public void SaveFileDetails(HttpPostedFileBase file, int id)
        {

            ItemImage newFile = new ItemImage();
            newFile.ContentType = file.ContentType;
            newFile.ItemID = id;
            newFile.ImageBytes = ConvertToBytes(file);
            if (file.ContentLength < (1024 * 1024) && (file.ContentType.Contains("/jpg") || file.ContentType.Contains("/jpeg") || file.ContentType.Contains("/png") || file.ContentType.Contains("/bmp")))
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    db.ItemImages.AddObject(newFile);
                    db.SaveChanges();
                }
            }
        }

        private byte[] ConvertToBytes(HttpPostedFileBase file)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(file.InputStream);
            imageBytes = reader.ReadBytes((int)file.ContentLength);
            return imageBytes;
        }
    }
}