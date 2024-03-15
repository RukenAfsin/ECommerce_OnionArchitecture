using ECommerceAPI.Application.Abstractions.DTOs;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Application.Security.Token;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ECommerceAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly ITokenHandler _tokenHandler;
        readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;
        readonly IUserService _userService;


        public AuthService(ITokenHandler tokenHandler, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IUserService userService)
        {
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = userService;
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
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 300);
                return token;
            }
            throw new AuthenticationErrorException();
        }

        public async  Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
          AppUser? user = await  _userManager.Users.FirstOrDefaultAsync(u=>u.RefreshToken == refreshToken);
            if(user !=null && user?.RefreshTokenEndDate>DateTime.UtcNow)
            {
               Token token =  _tokenHandler.CreateAccessToken(15,user);
              await  _userService.UpdateRefreshToken(token.RefreshToken,user, token.Expiration, 15);
                return token;
            }
           else 
                throw new NotFoundUserException();
        }
    }
}
