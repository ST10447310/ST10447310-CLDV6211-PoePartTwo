using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLDV6211_ST10447310.Data;
using CLDV6211_ST10447310.Models;
using Microsoft.Extensions.Logging;

namespace CLDV6211_ST10447310.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CLDV6211_ST10447310Context _context;

        public BookingsController(CLDV6211_ST10447310Context context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var cLDV6211_ST10447310Context = _context.Booking.Include(b => b.Event).Include(b => b.Venue);
            return View(await cLDV6211_ST10447310Context.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["EventID"] = new SelectList(_context.Set<Event>(), "EventID", "EventID");
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueID", "VenueID");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,VenueID,EventID,BookingDate")] Booking booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingBooking = _context.Booking.FirstOrDefault(b => b.VenueID == booking.VenueID && b.BookingDate.Date == booking.BookingDate.Date);
                    if (existingBooking == null)
                    {
                        _context.Add(booking);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Booking already exists.");

                    }
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "An unexpected error occurred. Please try again.");
            }

            ViewData["EventID"] = new SelectList(_context.Set<Event>(), "EventID", "EventName", booking.EventID);
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueID", "VenueName", booking.VenueID);

            return View(booking);

        }        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["EventID"] = new SelectList(_context.Set<Event>(), "EventID", "EventID", booking.EventID);
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueID", "VenueID", booking.VenueID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,VenueID,EventID,BookingDate")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventID"] = new SelectList(_context.Set<Event>(), "EventID", "EventID", booking.EventID);
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueID", "VenueID", booking.VenueID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking != null)
            {
                _context.Booking.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingID == id);
        }
    }
}
