namespace MovieShop.ApplicationCore.Models
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string? Overview { get; set; }
        public string? TagLine { get; set; }

        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? Price { get; set; }
        public decimal? Rating { get; set; }

        public int? RunTime { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }

        public string? ImdbUrl { get; set; }
        public string? TmdbUrl { get; set; }
        public string? OriginalLanguage { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }

        public IEnumerable<string>? Genres { get; set; }
        public IEnumerable<TrailerModel>? Trailers { get; set; }
        public IEnumerable<CastModel>? Cast { get; set; }
        public IEnumerable<ReviewModel>? Reviews { get; set; }
    }
}
