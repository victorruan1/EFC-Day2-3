namespace MovieShop.ApplicationCore.Models
{
    public class CastDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ProfilePath { get; set; }
        public IEnumerable<(int MovieId, string Title)> Movies { get; set; } =
            new List<(int, string)>();
    }
}
