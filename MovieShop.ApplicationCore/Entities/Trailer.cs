using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.ApplicationCore.Entities;

public class Trailer
{
    public int Id { get; set; }

    [MaxLength(256)]
    public string Name { get; set; }

    [MaxLength(256)]
    public string TrailerUrl { get; set; }

    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}
