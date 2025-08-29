using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.Infrastructure.Services;

public class AccountService : IAccountService
{
    public Task<bool> RegisterAsync(string firstName, string lastName, string email, string password)
        => Task.FromResult(true);

    public Task<bool> LoginAsync(string email, string password)
        => Task.FromResult(true);
}
