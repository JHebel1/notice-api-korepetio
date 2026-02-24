using Microsoft.EntityFrameworkCore;
using Notices.Domain.Entities;
using Notices.Domain.RepositoryInterfaces;
using Notices.Infrastructure.Database;

namespace Notices.Infrastructure.Repositories;

public class UserRepository(NoticesDbContext userDbContext) : IUserRepository
{
    public async Task<User> GetUserById(Guid id, CancellationToken token)
    {
        var user = await userDbContext.Users.FindAsync(id, token);
        if (user is null)
            throw new InvalidOperationException($"User with id '{id}' not found.");
        return user;
    }

    public async Task<Guid> AddAsync(User user)
    {
        await userDbContext.Users.AddAsync(user);
        await userDbContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task<Guid> GetUserIdByIdentityProviderId(Guid identityProviderId, CancellationToken token)
    {
        var userId = await userDbContext.Users
            .Where(x => x.IdentityProviderId == identityProviderId)
            .Select(x => x.Id)
            .Cast<Guid?>()
            .FirstOrDefaultAsync(token);
        if (userId is null || userId == Guid.Empty)
        {
            throw new KeyNotFoundException($"User with identityProviderId '{identityProviderId}' not found.");
        }
        return userId.Value;
    }
}