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
        readonly UserManager<p.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<p.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

         IdentityResult result=  await  _userManager.CreateAsync(new()
            {
              Id=Guid.NewGuid().ToString(),   
               UserName=request.UserName,
               Email= request.Email,
               NameSurname=request.NameSurname,            
            },request.Password);

            CreateUserCommandResponse response= new() {Succeeded = result.Succeeded};

            if (result.Succeeded)
                response.Message = "User created successfully";
            else
            
                foreach(var error in result.Errors)
                {
                    response.Message += $"{error.Code}-{error.Description}";
                }
            return response;
         
        }
    }
}
