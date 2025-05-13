using System.ComponentModel.DataAnnotations;

namespace CLDV6211_ST10447310.Models
{
    public class BookingMade
    {
        [Key]
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }

        public int EventID { get; set; }
        public string EventName { get; set; } = default!;
        public DateTime EventDate { get; set; }
        public string Description { get; set; } = default!;

        public int VenueID { get; set; }
        public string VenueName { get; set; } = default!;
        public string Location { get; set; } = default!;
        public int Capacity { get; set; }
    }
}

