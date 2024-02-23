using ECommerceAPI.Application.Abstractions.DTOs.User;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p = ECommerceAPI.Domain.Entities.Identity;

namespace ECommerceAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

          CreateUserResponse response =await   _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname=request.NameSurname,
                Password= request.Password,
                PasswordConfirm= request.PasswordConfirm,
                UserName= request.UserName,
            });
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
         
        }
    }
}
