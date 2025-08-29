using System.ComponentModel.DataAnnotations;

namespace MovieShop.ApplicationCore.Entities
{
    public class MovieCast
    {
        [Required]
        public int CastId { get; set; }

        [Required, StringLength(450)]
        public string Character { get; set; } = string.Empty;

        [Required]
        public int MovieId { get; set; }

        public Cast Cast { get; set; }
        public Movie Movie { get; set; }
    }
}
