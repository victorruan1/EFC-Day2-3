namespace MovieShop.ApplicationCore.Contracts.Services;

public interface IAccountService
{
    Task<bool> RegisterAsync(string firstName, string lastName, string email, string password);
    Task<bool> LoginAsync(string email, string password);
}
