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
    public class FlightCustomerDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlightCustomerDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FlightCustomerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightCustomerDetails>>> GetFlightCustomerDetails()
        {
          if (_context.FlightCustomerDetails == null)
          {
              return NotFound();
          }
            return await _context.FlightCustomerDetails.ToListAsync();
        }

        // GET: api/FlightCustomerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightCustomerDetails>> GetFlightCustomerDetails(int id)
        {
          if (_context.FlightCustomerDetails == null)
          {
              return NotFound();
          }
            var flightCustomerDetails = await _context.FlightCustomerDetails.FindAsync(id);

            if (flightCustomerDetails == null)
            {
                return NotFound();
            }

            return flightCustomerDetails;
        }

        // PUT: api/FlightCustomerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightCustomerDetails(int id, FlightCustomerDetails flightCustomerDetails)
        {
            if (id != flightCustomerDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightCustomerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightCustomerDetailsExists(id))
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

        // POST: api/FlightCustomerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightCustomerDetails>> PostFlightCustomerDetails(FlightCustomerDetails flightCustomerDetails)
        {
          if (_context.FlightCustomerDetails == null)
          {
              return Problem("Entity set 'ApplicationDbContext.FlightCustomerDetails'  is null.");
          }
            _context.FlightCustomerDetails.Add(flightCustomerDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightCustomerDetails", new { id = flightCustomerDetails.Id }, flightCustomerDetails);
        }

        // DELETE: api/FlightCustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightCustomerDetails(int id)
        {
            if (_context.FlightCustomerDetails == null)
            {
                return NotFound();
            }
            var flightCustomerDetails = await _context.FlightCustomerDetails.FindAsync(id);
            if (flightCustomerDetails == null)
            {
                return NotFound();
            }

            _context.FlightCustomerDetails.Remove(flightCustomerDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightCustomerDetailsExists(int id)
        {
            return (_context.FlightCustomerDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
