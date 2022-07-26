using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraWebsiteApi.Data;
using SumeraWebsiteApi.Data.Dto;
using SumeraWebsiteApi.Data.Models;

namespace SumeraWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
          if (_context.Flights == null)
          {
              return NotFound();
          }
            return await _context.Flights.ToListAsync();
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
          if (_context.Flights == null)
          {
              return NotFound();
          }
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        // GET: api/Flights/BOM/DEL/////
        // GET: api/Flights/BOM/DEL/25-Jun-2022
        //[HttpGet("{fromAirport}/{toAirport}/{date}")]
        //public async Task<ActionResult<List<FlightBookingDto>>> GetFlight(string fromAirport, string toAirport, DateTime date)
        //{
        //    if(!(await _context.Airlines.AnyAsync(f =>f.Name == fromAirport)&&
        //        await _context.Airlines.AnyAsync(f=>f.Name == toAirport)))
        //    return NotFound();
       
        //    var fromAirportRefId = await _context.Airlines
        //        .Where(l=> l.Name == fromAirport)
        //        .Select(l=>l.Id)
        //        .FirstOrDefaultAsync();

        //    var toAirportRefId = _context.Airlines
        //           .Where(l => l.Name == toAirport)
        //           .Select(l => l.Id)
        //           .FirstOrDefaultAsync();

        //    var filterDateFrom = date;
        //    var filterDateTo = date.AddHours(24).AddSeconds(-1);
        //    var flightQuery = _context.Flights
        //        .Where(f=>
        //        f.FromAirportRefId == fromAirportRefId &&
        //        f.ToAirportRefId == toAirportRefId &&
        //        f.DepartureDate

        //}



            // PUT: api/Flights/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
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

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
          if (_context.Flights == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Flights'  is null.");
          }
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            if (_context.Flights == null)
            {
                return NotFound();
            }
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(int id)
        {
            return (_context.Flights?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
