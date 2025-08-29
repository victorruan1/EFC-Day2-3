using MovieShop.ApplicationCore.Contracts.Repository;

namespace MovieShop.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private static readonly HashSet<string> _emails = new(StringComparer.OrdinalIgnoreCase)
    {
        "demo@movieshop.local"
    };

    public Task<bool> ExistsByEmailAsync(string email) =>
        Task.FromResult(_emails.Contains(email));
}
