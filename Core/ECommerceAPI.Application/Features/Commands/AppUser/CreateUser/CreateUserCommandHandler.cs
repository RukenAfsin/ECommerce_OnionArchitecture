using ECommerceAPI.Application.Abstractions.DTOs.User;
using ECommerceAPI.Application.Abstractions.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

          CreateUserResponseDTO response =await   _userService.CreateAsync(new()
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
