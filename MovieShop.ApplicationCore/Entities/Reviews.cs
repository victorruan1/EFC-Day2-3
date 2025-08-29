using System.ComponentModel.DataAnnotations;

namespace MovieShop.ApplicationCore.Entities
{
    public class Review
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public decimal Rating { get; set; }

        [Required]
        public string ReviewText { get; set; } = string.Empty;

        public Movie Movie { get; set; } = default!;
        public User User { get; set; } = default!;
    }
}
