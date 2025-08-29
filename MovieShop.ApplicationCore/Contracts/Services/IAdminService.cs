namespace MovieShop.ApplicationCore.Contracts.Services;

public interface IAdminService
{
    Task<IEnumerable<(string Title, int Purchases)>> GetTopPurchasedMoviesAsync(int take = 50);
}
