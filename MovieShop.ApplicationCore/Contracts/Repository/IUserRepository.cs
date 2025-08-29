namespace MovieShop.ApplicationCore.Contracts.Repository;

public interface IUserRepository
{
    Task<bool> ExistsByEmailAsync(string email);
}
