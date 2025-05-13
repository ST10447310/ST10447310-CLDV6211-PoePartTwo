using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CLDV6211_ST10447310.Models;

namespace CLDV6211_ST10447310.Data
{
    public class CLDV6211_ST10447310Context : DbContext
    {
        public CLDV6211_ST10447310Context (DbContextOptions<CLDV6211_ST10447310Context> options)
            : base(options)
        {
        }

        public DbSet<CLDV6211_ST10447310.Models.Booking> Booking { get; set; } = default!;
        public DbSet<CLDV6211_ST10447310.Models.Event> Event { get; set; } = default!;
        public DbSet<CLDV6211_ST10447310.Models.Venue> Venue { get; set; } = default!;
        public DbSet<CLDV6211_ST10447310.Models.BookingMade> BookingMade { get; set; } = default!;
    }
}
