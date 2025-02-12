namespace RSVP
{
    public class User
    {
        //public int SN { get; set; }
        public int No { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool WillAttend { get; set; }
        public bool ComingWithAGuest { get; set; }
        public int NumberOfGuests { get; set; }
        public List<string>? GuestNames { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<HotelReservation> HotelReservations { get; set; }

    }

    public class HotelReservation
    {
        public int SN { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public HotelType HotelName { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
