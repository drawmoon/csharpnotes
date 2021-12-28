using DomainPrimitive.EntityFrameworkCore.Entities;

namespace DomainPrimitive.Domain.Model.User;

public interface IUserRepository
{
    Task<IdentityUser?> Get(Username username);

    Task<IdentityUser?> Get(Email email);

    Task<IdentityUser> Register(IdentityUser user);
}