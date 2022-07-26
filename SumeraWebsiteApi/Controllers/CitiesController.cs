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
using SumeraWebsiteApi.services;

namespace SumeraWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public readonly ICityService  _cityService ;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<List<CityDto>>> Getcities()
        {
            //if (_context.cities == null)
            //{
            //    return NotFound();
            //}
            //    var cities = _cityservice.ciInclude("Country").Select(x => new {id=x.Id,name=x.Name,cname=x.Country.Name}).ToList();
            //   return Ok(cities);

            return await _cityService.GetAllAsync();  
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int? id)
        {
          if (id == null)
          {
              return NotFound();
          }
            var city = await _cityService.GetByIdAsync((int)id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, CityDto city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            //.Entry(city).State = EntityState.Modified;

            try
            {
                await _cityService.UpdateAsync(city);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(CityDto city)
        {
          if (city == null)
          {
              return Problem("Entity set 'ApplicationDbContext.cities'  is null.");
          }
           await _cityService.CreateAsync(city);

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var city = await _cityService.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }

           await _cityService.DeleteAsync(id);

            return NoContent();
        }

        private bool CityExists(int id)
        {
          return _cityService.GetByIdAsync(id) != null; 
        }
    }
}
