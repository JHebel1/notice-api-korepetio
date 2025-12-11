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
}