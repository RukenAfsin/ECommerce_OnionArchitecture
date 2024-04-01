using ECommerceAPI.Application.Abstractions.DTOs.User;
using ECommerceAPI.Application.Abstractions.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

          CreateUserResponseDTO response =await   _userService.CreateAsync(new()
            {
              NameSurname = request.NameSurname,
              UserName = request.UserName,
              Email = request.Email,
              Password= request.Password,
              PasswordConfirm= request.PasswordConfirm,

            });
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
        }
    }
}
