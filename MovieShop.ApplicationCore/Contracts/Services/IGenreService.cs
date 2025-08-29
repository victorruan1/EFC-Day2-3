namespace MovieShop.ApplicationCore.Contracts.Services;

public interface IGenreService
{
    Task<IEnumerable<string>> GetAllAsync();
}
