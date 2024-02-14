using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public async Task DeleteAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public async Task<string> UpdateAsync(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
            return await UploadAsync(file, root);
        }

        public async Task<string> UploadAsync(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string filePath = Path.Combine(root, guid + extension);

                using (FileStream fileStream = File.Create(filePath))
                {
                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                    return filePath;
                }
            }
            return string.Empty; // veya null yerine boş bir string döndürebilirsiniz.
        }
    }
}
