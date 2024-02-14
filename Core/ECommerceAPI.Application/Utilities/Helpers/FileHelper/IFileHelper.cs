using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Utilities.Helpers.FileHelper
{
   public interface IFileHelper
    {

        Task<string> UploadAsync(IFormFile file, string root);
        Task DeleteAsync(string filePath);
        Task<string> UpdateAsync(IFormFile file, string filePath, string root);

    }
}
