using ECommerceAPI.Application.Services;
using ETicaretAPI.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services
{
    public class FileService : IFileService
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write,
              FileShare.None, 1024 * 1024, useAsync: false);

                await fileStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public async Task<string> FileRenameAsync(string path, string fileName, bool first = true)
        {
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string newFileName = fileName;


            int fileno = 0;
            while (true)
            {
                if (File.Exists($"{path}\\{newFileName}"))
                {
                    fileno++;
                    //   newFileName = Path.GetFileNameWithoutExtension(oldName) +"-"+fileno.ToString() + extension;    
                    newFileName = oldName + "-" + fileno.ToString() + extension;
                }
                else
                {
                    break;
                }
            }
            return newFileName;
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, FormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            List<bool> results = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(uploadPath, file.FileName);


                bool result = await CopyFileAsync($"{uploadPath}\\ {fileNewName}", file);
                datas.Add((fileNewName, $"{uploadPath}\\ {fileNewName}"));
                results.Add(result);
            }
            if (results.TrueForAll(R => R.Equals(true)))

                return datas;
            return null;

            //todo if results.TrueForAll is not valid there should be exception method for users receive a fail when files uploading.



        }


    }
}
