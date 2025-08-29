using MovieShop.ApplicationCore.Contracts.Repository;

namespace MovieShop.Infrastructure.Repository;

public class PurchaseRepository : IPurchaseRepository
{
    public Task<int> CountPurchasesForMovieAsync(int movieId) => Task.FromResult(Random.Shared.Next(1, 100));
}
