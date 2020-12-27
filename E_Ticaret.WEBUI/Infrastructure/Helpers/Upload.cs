using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Infrastructure.Helpers
{
    public static class Upload
    {
        public static string imageUpload(List<IFormFile> files, IWebHostEnvironment env, out bool result)
        {
            result = false;
            var uploads = Path.Combine(env.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.ContentType.Contains("image"))
                {
                    if (file.Length <= 3000000)
                    {
                        string uniqueName =
                            $"{Guid.NewGuid().ToString().Replace('-', '_').ToLower()}.{file.ContentType.Split("/")[1]}";
                        var filepath = Path.Combine(uploads, uniqueName);
                        using (var fileStream = new FileStream(filepath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            result = true;
                            return filepath.Substring(filepath.IndexOf("\\uploads\\"));
                        }
                    }
                    else
                        return "Dosya Boyutu 3MB'den ve düşük olmalıdır.";
                }
                else
                    return "Lütfen sadece resim yükleyiniz.";
            }
            return "Dosya Bulunamadı!";
        }
    }
}
