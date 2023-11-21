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
        [JsonIgnore]
        [StringLength(16)]
        public string? NewPassword { get; set; } = null;
        [JsonIgnore]
        [StringLength(200)]
		public string? ResetPasswordToken { get; set; } = null;
        [JsonIgnore]
        [StringLength(200)]
        public string? ActiveAccountToken { get; set; } = null;
		public string? Role { get; set; } = null!;
	}
}
