namespace MovieShop.ApplicationCore.Contracts.Repository;

public interface IReportRepository
{
    Task<IEnumerable<(int MovieId, int Purchases)>> GetTopPurchasedMoviesAsync(int take = 25);
}
