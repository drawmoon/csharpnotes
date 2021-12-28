using DomainPrimitive.Application.Command;
using DomainPrimitive.Application.Dto;

namespace DomainPrimitive.Domain.Services;

public interface IAccountService
{
    Task<UserDto> Register(CreateUserCommand createUserCommand);
}