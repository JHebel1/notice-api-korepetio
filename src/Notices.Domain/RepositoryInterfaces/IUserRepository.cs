using Notices.Domain.Entities;

namespace Notices.Domain.RepositoryInterfaces;

public interface IUserRepository
{
    Task<User> GetUserById(Guid userId, CancellationToken token);
}