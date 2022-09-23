using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        public string Update(IFormFile file, string filepath, string root)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length>0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string filepath= guid+ extension;

                using (FileStream fileStream = File.Create(root + filepath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filepath;
                }
            }
            return null;
        }
    }
}
