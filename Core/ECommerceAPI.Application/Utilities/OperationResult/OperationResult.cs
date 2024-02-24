using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Utilities.OperationResult
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }


        public OperationResult(bool success, string errorMessage = "")
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
