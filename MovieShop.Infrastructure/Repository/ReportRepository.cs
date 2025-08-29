using MovieShop.ApplicationCore.Contracts.Repository;

namespace MovieShop.Infrastructure.Repository;

public class ReportRepository : IReportRepository
{
    public Task<IEnumerable<(int MovieId, int Purchases)>> GetTopPurchasedMoviesAsync(int take = 25)
    {
        var data = Enumerable.Range(1, take).Select(i => (MovieId: i, Purchases: Random.Shared.Next(1, 100)));
        return Task.FromResult(data);
    }
}
