using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CLDV6211_ST10447310.Data;
using CLDV6211_ST10447310.Models;

namespace CLDV6211_ST10447310.Controllers
{
    public class BookingMadesController : Controller
    {
        private readonly CLDV6211_ST10447310Context _context;

        public BookingMadesController(CLDV6211_ST10447310Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> BookingMade(string? searchString)
        {
            var query = _context.Booking
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(b =>
                    b.BookingID.ToString().Contains(searchString) ||
                    b.Event.EventName.Contains(searchString));
            }

            var data = await query.Select(b => new BookingMade
            {
                BookingID = b.BookingID,
                BookingDate = b.BookingDate,

                EventID = b.EventID,
                EventName = b.Event.EventName,
                EventDate = b.Event.EventDate,
                Description = b.Event.Description,

                VenueID = b.VenueID,
                VenueName = b.Venue.VenueName,
                Location = b.Venue.Location,
                Capacity = b.Venue.Capacity,

            }).ToListAsync();

            return View(data);
        }
    }
}
