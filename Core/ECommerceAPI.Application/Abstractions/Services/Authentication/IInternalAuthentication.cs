using ECommerceAPI.Application.Abstractions.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services.Authentication
{
    public interface IInternalAuthentication
    {
        Task<Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime);
    }
}
