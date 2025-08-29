using System.ComponentModel.DataAnnotations;
using MovieShop.ApplicationCore.Entities;

public class Purchase
{
    public int MovieId { get; set; }
    public int UserId { get; set; }

    [Required]
    public DateTime PurchaseDateTime { get; set; }

    [Required]
    public Guid PurchaseNumber { get; set; }

    public decimal TotalPrice { get; set; }

    public Movie Movie { get; set; } = default!;
    public User User { get; set; } = default!;
}
