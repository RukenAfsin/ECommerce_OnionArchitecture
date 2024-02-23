using ECommerceAPI.Application.Abstractions.DTOs;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Application.Security.Token;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;


namespace ECommerceAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly ITokenHandler _tokenHandler;
        readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;


        public AuthService(ITokenHandler tokenHandler, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userManager = userManager;
        }



        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
           AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded) 
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                return token;
            }
            throw new AuthenticationErrorException();
        }
    }
}
