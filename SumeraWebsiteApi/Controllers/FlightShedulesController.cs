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
    public class FlightShedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlightShedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FlightShedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightShedule>>> GetFlightsShedules()
        {
          if (_context.FlightsShedules == null)
          {
              return NotFound();
          }
            return await _context.FlightsShedules.ToListAsync();
        }

        // GET: api/FlightShedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightShedule>> GetFlightShedule(int id)
        {
          if (_context.FlightsShedules == null)
          {
              return NotFound();
          }
            var flightShedule = await _context.FlightsShedules.FindAsync(id);

            if (flightShedule == null)
            {
                return NotFound();
            }

            return flightShedule;
        }

        // PUT: api/FlightShedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightShedule(int id, FlightShedule flightShedule)
        {
            if (id != flightShedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightShedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightSheduleExists(id))
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

        // POST: api/FlightShedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightShedule>> PostFlightShedule(FlightShedule flightShedule)
        {
          if (_context.FlightsShedules == null)
          {
              return Problem("Entity set 'ApplicationDbContext.FlightsShedules'  is null.");
          }
            _context.FlightsShedules.Add(flightShedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightShedule", new { id = flightShedule.Id }, flightShedule);
        }

        // DELETE: api/FlightShedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightShedule(int id)
        {
            if (_context.FlightsShedules == null)
            {
                return NotFound();
            }
            var flightShedule = await _context.FlightsShedules.FindAsync(id);
            if (flightShedule == null)
            {
                return NotFound();
            }

            _context.FlightsShedules.Remove(flightShedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightSheduleExists(int id)
        {
            return (_context.FlightsShedules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
