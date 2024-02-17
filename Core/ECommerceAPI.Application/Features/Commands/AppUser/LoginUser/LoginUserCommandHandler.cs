using ECommerceAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p = ECommerceAPI.Domain.Entities.Identity;

namespace ECommerceAPI.Application.Features.Commands.AppUser.LoginUser
{
    public  class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<p.AppUser> _userManager;
        readonly SignInManager<p.AppUser> _signInManager;
        public LoginUserCommandHandler(UserManager<p.AppUser> userManager, SignInManager<p.AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            p.AppUser user =await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user == null)
                throw new NotFoundUserException("User Name or password Error");

          SignInResult result= await  _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {

            }

            return null;
          
        }
    }
}
