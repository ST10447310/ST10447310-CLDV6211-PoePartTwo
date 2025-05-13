using System.ComponentModel.DataAnnotations;

namespace CLDV6211_ST10447310.Models
{
    public class Event
    {
        [Key]

        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        [Display(Name = "Event Name")]
        public string EventName { get; set; } = string.Empty;

        [Display(Name = "Event Date and Time")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Event Description")]
        public string Description { get; set; } = string.Empty;
    }
}
