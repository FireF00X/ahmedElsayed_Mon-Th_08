using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            // 1- Get Folder Path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

            // 2- Get file Name
            var fileName = file.FileName;

            // 3- combine folderPath + FilePath
            var filePath = Path.Combine(folderPath, fileName);

            // 4- save file
            using var filteStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(filteStream);

            return filePath;
        }
    }
}
