using MovieShop.ApplicationCore.Entities;

public class Favorite
{
    public int MovieId { get; set; }
    public int UserId { get; set; }

    public Movie Movie { get; set; } = default!;
    public User User { get; set; } = default!;
}
