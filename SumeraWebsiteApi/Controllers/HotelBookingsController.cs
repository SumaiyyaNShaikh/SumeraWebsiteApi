using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraWebsiteApi.Data;
using SumeraWebsiteApi.Data.Models;

namespace SumeraWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HotelBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelBooking>>> GetHotelBookings()
        {
          if (_context.HotelBookings == null)
          {
              return NotFound();
          }
            return await _context.HotelBookings.ToListAsync();
        }

        // GET: api/HotelBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelBooking>> GetHotelBooking(int id)
        {
          if (_context.HotelBookings == null)
          {
              return NotFound();
          }
            var hotelBooking = await _context.HotelBookings.FindAsync(id);

            if (hotelBooking == null)
            {
                return NotFound();
            }

            return hotelBooking;
        }

        // PUT: api/HotelBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelBooking(int id, HotelBooking hotelBooking)
        {
            if (id != hotelBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelBookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HotelBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelBooking>> PostHotelBooking(HotelBooking hotelBooking)
        {
          if (_context.HotelBookings == null)
          {
              return Problem("Entity set 'ApplicationDbContext.HotelBookings'  is null.");
          }
            _context.HotelBookings.Add(hotelBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelBooking", new { id = hotelBooking.Id }, hotelBooking);
        }

        // DELETE: api/HotelBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelBooking(int id)
        {
            if (_context.HotelBookings == null)
            {
                return NotFound();
            }
            var hotelBooking = await _context.HotelBookings.FindAsync(id);
            if (hotelBooking == null)
            {
                return NotFound();
            }

            _context.HotelBookings.Remove(hotelBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelBookingExists(int id)
        {
            return (_context.HotelBookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
