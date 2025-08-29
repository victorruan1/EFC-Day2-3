using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Services;

public class GenreService : IGenreService
{
    private readonly MovieShopDbContext _context;

    public GenreService(MovieShopDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<string>> GetAllAsync()
    {
        return await _context.Genres.AsNoTracking().Select(g => g.Name).ToListAsync();
    }
}
