namespace MovieShop.ApplicationCore.Models
{
    public class ReviewModel
    {
        public decimal Rating { get; set; }
        public string ReviewText { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
