using Azure.Core;
using ECommerceAPI.Application.Abstractions.DTOs.User;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Features.Commands.AppUser.CreateUser;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async  Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                NameSurname = model.NameSurname,
            }, model.Password);

            CreateUserResponseDTO response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "User created successfully";
            else

                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code}-{error.Description}";
                }
            return response;
        }
    }
}
