using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PizzaBookingShared.Entities
{
	public class User : TimeRecord
	{
        public int Id { get; set; }
		[Required, MaxLength(50), EmailAddress]
        public string LoginName { get; set; } = null!;
		[JsonIgnore, StringLength(100)]
		public string HashedPassword { get; set; } = null!;
		[Required, MaxLength(50)]
		public string FirstName { get; set; } = null!;
        [Required, MaxLength(50)]
        public string LastName { get; set; } = null!;
        [Required, MaxLength(50)]
        public string PhoneNumber { get; set; } = null!;
        [MaxLength(200)]
        public string? Addresss { get; set; }
		public int LoginFailedCount { get; set; }
		public bool Locked { get; set; } = false;
		public string? Role { get; set; } = null!;
	}
}
