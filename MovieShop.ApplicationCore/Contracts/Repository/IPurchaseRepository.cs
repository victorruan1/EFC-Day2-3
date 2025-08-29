namespace MovieShop.ApplicationCore.Contracts.Repository;

public interface IPurchaseRepository
{
    Task<int> CountPurchasesForMovieAsync(int movieId);
}
