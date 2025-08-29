using MovieShop.ApplicationCore.Entities;

public class UserRole
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

    // Navigation
    public User User { get; set; } = default!;
    public Role Role { get; set; } = default!;
}
