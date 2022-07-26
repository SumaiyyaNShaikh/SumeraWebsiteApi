using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraWebsiteApi.Data;
using SumeraWebsiteApi.Data.Models;
using SumeraWebsiteApi.services;

namespace SumeraWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryCurdService _countryCurdService;

        public CountriesController(ICountryCurdService countryCurdService)
        {
            _countryCurdService = countryCurdService;
        }
        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
          //if (_context.Countries == null)
          //{
          //    return NotFound();
          //}
          //  return await _context.Countries.ToListAsync();
          return await _countryCurdService.GetAllAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int? id)
        {
          if (id == null)
          {
              return NotFound();
          }
            var country = await _countryCurdService.GetByIdAsync((int)id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }
            // await _countryCurdService.UpdateAsync(country);
            try
            {
                await _countryCurdService.UpdateAsync((Country)country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
          if (_countryCurdService == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Countries'  is null.");
          }
            //_countryCurdService.CreateAsync(country);
            //await _countryCurdService.SaveChangesAsync();
            
            await _countryCurdService.CreateAsync(country);
   
            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var country = _countryCurdService.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }

             await _countryCurdService.DeleteAsync(id);

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _countryCurdService.GetByIdAsync(id) != null;
        }
    }
}
