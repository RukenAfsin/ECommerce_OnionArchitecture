using ECommerceAPI.Application.Abstractions.DTOs;
using ECommerceAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p = ECommerceAPI.Application.Abstractions.DTOs;

namespace ECommerceAPI.Application.Security.Token
{
    public interface ITokenHandler
    {
        p.Token CreateAccessToken(int second, AppUser appUser);
       string  CreateRefreshToken();
    }
}
