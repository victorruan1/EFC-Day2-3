using System.ComponentModel.DataAnnotations;

namespace MovieShop.ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, StringLength(256)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(128)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(128)]
        public string LastName { get; set; } = string.Empty;

        [Required, StringLength(1024)]
        public string HashedPassword { get; set; } = string.Empty;

        [Required, StringLength(1024)]
        public string Salt { get; set; } = string.Empty;

        public bool IsLocked { get; set; }

        [StringLength(16)]
        public string? PhoneNumber { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
