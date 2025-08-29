using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo) => _userRepo = userRepo;

    public async Task<bool> EmailAvailableAsync(string email) =>
        !await _userRepo.ExistsByEmailAsync(email);
}
