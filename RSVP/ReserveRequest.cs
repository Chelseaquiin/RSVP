using System.ComponentModel.DataAnnotations;

namespace RSVP
{
    public class UserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool WillAttend { get; set; }
        public bool ComingWithAGuest { get; set; }
        public int NumberOfGuests { get; set; }
        public List<string> GuestNames { get; set; }
    }

    public class HotelRequest
    {
        public string UserId { get; set; }
        public bool ReserveAHotel { get; set; }
        public HotelType HotelName { get; set; }
        public int NumberOfDays { get; set; }
    }

    public class EmailRequest
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        
    }

    public enum HotelType
    {
        SuperNike,
        AZ,
        OsborneOldSite,
        OsborneNewSite
    }
}
