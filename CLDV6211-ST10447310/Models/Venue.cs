using System.ComponentModel.DataAnnotations;

namespace CLDV6211_ST10447310.Models
{
    public class Venue
    {
        [Key]
        [Display(Name = "Venue ID")]
        public int VenueID { get; set; }
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; } = string.Empty;
        [Display(Name = "Venue Location")]
        public string Location { get; set; } = string.Empty;

        [Display(Name = "Venue Capacity")]
        public int Capacity { get; set; }

        public string? image {  get; set; }
    }
}
