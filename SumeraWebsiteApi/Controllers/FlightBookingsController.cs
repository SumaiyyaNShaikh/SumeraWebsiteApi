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
    public class FlightBookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlightBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FlightBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightBooking>>> GetFlightBookings()
        {
          if (_context.FlightBookings == null)
          {
              return NotFound();
          }
            return await _context.FlightBookings.ToListAsync();
        }

        // GET: api/FlightBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightBooking>> GetFlightBooking(int id)
        {
          if (_context.FlightBookings == null)
          {
              return NotFound();
          }
            var flightBooking = await _context.FlightBookings.FindAsync(id);

            if (flightBooking == null)
            {
                return NotFound();
            }

            return flightBooking;
        }

        // PUT: api/FlightBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightBooking(int id, FlightBooking flightBooking)
        {
            if (id != flightBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightBookingExists(id))
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

        // POST: api/FlightBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightBooking>> PostFlightBooking(FlightBooking flightBooking)
        {
          if (_context.FlightBookings == null)
          {
              return Problem("Entity set 'ApplicationDbContext.FlightBookings'  is null.");
          }
            _context.FlightBookings.Add(flightBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightBooking", new { id = flightBooking.Id }, flightBooking);
        }

        // DELETE: api/FlightBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightBooking(int id)
        {
            if (_context.FlightBookings == null)
            {
                return NotFound();
            }
            var flightBooking = await _context.FlightBookings.FindAsync(id);
            if (flightBooking == null)
            {
                return NotFound();
            }

            _context.FlightBookings.Remove(flightBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightBookingExists(int id)
        {
            return (_context.FlightBookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
