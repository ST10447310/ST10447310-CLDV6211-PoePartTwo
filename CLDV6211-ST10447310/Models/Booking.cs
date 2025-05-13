using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLDV6211_ST10447310.Models
{
    public class Booking
    {
        [Key]
        [Display(Name = "Booking ID")]
        public int BookingID { get; set; }

        [Required]
        [Display(Name = "Venue ID")]
        public int VenueID { get; set; }

        [ForeignKey(nameof(VenueID))]
        public Venue? Venue { get; set; }

        [Required]
        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        [ForeignKey(nameof(EventID))]
        public Event? Event { get; set; }

        [Required]

        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }
    }
}

