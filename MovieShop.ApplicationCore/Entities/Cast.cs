using System.ComponentModel.DataAnnotations;

namespace MovieShop.ApplicationCore.Entities
{
    public class Cast
    {
        public int Id { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required, StringLength(128)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2084)]
        public string? ProfilePath { get; set; }

        public string? TmdbUrl { get; set; }

        // Navigation property
        public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
    }
}
