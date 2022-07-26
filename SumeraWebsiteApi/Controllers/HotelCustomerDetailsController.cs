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
    public class HotelCustomerDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelCustomerDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HotelCustomerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelCustomerDetails>>> GetHotelCustomerDetails()
        {
          if (_context.HotelCustomerDetails == null)
          {
              return NotFound();
          }
            return await _context.HotelCustomerDetails.ToListAsync();
        }

        // GET: api/HotelCustomerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelCustomerDetails>> GetHotelCustomerDetails(int id)
        {
          if (_context.HotelCustomerDetails == null)
          {
              return NotFound();
          }
            var hotelCustomerDetails = await _context.HotelCustomerDetails.FindAsync(id);

            if (hotelCustomerDetails == null)
            {
                return NotFound();
            }

            return hotelCustomerDetails;
        }

        // PUT: api/HotelCustomerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelCustomerDetails(int id, HotelCustomerDetails hotelCustomerDetails)
        {
            if (id != hotelCustomerDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelCustomerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelCustomerDetailsExists(id))
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

        // POST: api/HotelCustomerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelCustomerDetails>> PostHotelCustomerDetails(HotelCustomerDetails hotelCustomerDetails)
        {
          if (_context.HotelCustomerDetails == null)
          {
              return Problem("Entity set 'ApplicationDbContext.HotelCustomerDetails'  is null.");
          }
            _context.HotelCustomerDetails.Add(hotelCustomerDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelCustomerDetails", new { id = hotelCustomerDetails.Id }, hotelCustomerDetails);
        }

        // DELETE: api/HotelCustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelCustomerDetails(int id)
        {
            if (_context.HotelCustomerDetails == null)
            {
                return NotFound();
            }
            var hotelCustomerDetails = await _context.HotelCustomerDetails.FindAsync(id);
            if (hotelCustomerDetails == null)
            {
                return NotFound();
            }

            _context.HotelCustomerDetails.Remove(hotelCustomerDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelCustomerDetailsExists(int id)
        {
            return (_context.HotelCustomerDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
