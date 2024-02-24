using ECommerceAPI.Application.Utilities.OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.SomeFeatures.Rules
{
    public class BusinessRules
    {
        public static OperationResult Run(params OperationResult[] results)
        {
            foreach(var result in results)
            {
                if(!result.Success)
                {
                    return result;
                }
            }
            return new OperationResult(true);
        }
    }
}
