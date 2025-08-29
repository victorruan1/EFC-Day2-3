namespace MovieShop.ApplicationCore.Contracts.Services;

public interface IUserService
{
    Task<bool> EmailAvailableAsync(string email);
}
