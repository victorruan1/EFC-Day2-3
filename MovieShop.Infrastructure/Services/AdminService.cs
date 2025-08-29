using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.Infrastructure.Services;

public class AdminService : IAdminService
{
    private readonly IReportRepository _reportRepository;

    public AdminService(IReportRepository reportRepository) => _reportRepository = reportRepository;

    public async Task<IEnumerable<(string Title, int Purchases)>> GetTopPurchasedMoviesAsync(int take = 50)
    {
        var top = await _reportRepository.GetTopPurchasedMoviesAsync(take);
        // Title is synthesized for demo
        return top.Select(x => ($"Movie #{x.MovieId}", x.Purchases));
    }
}
