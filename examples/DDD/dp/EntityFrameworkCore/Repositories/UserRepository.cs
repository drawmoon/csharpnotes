using DomainPrimitive.Domain.Model.User;
using DomainPrimitive.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainPrimitive.EntityFrameworkCore.Repositories;

public class UserRepository : BaseRepository<IdentityUser>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IdentityUser?> Get(Username username)
    {
        return await Entities.FirstOrDefaultAsync(x => x.Name == username);
    }

    public async Task<IdentityUser?> Get(Email email)
    {
        return await Entities.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<IdentityUser> Register(IdentityUser user)
    {
        await Entities.AddAsync(user);
        await SaveChangesAsync();

        return user;
    }
}