using System.Text.Json.Serialization;

namespace PizzaBookingShared.ViewModel
{
    public abstract class UserViewModel : TimeRecord
    {
        public int Id { get; set; }
        public string LoginName { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Addresss { get; set; }
        public int LoginFailedCount { get; set; }
        public int? LoginStatusId { get; set; }
    }
}
