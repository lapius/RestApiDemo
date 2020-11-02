using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestDemo.Contexts;
using RestDemo.Entities;

namespace RestDemo.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherInfoesController : ControllerBase
    {
        private readonly WeatherContext _context;

        public WeatherInfoesController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/weather
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherInfo>>> GetWeatherInfo()
        {
            return await _context.WeatherInfo.ToListAsync();
        }

        // GET: api/weather/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherInfo>> GetWeatherInfo(int id)
        {
            var weatherInfo = await _context.WeatherInfo.FindAsync(id);

            if (weatherInfo == null)
            {
                return NotFound();
            }

            return weatherInfo;
        }

        // PUT: api/weather/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherInfo(int id, WeatherInfo weatherInfo)
        {
            if (id != weatherInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherInfoExists(id))
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

        // POST: api/weather
        [HttpPost]
        public async Task<ActionResult<WeatherInfo>> PostWeatherInfo(WeatherInfo weatherInfo)
        {
            _context.WeatherInfo.Add(weatherInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherInfo", new { id = weatherInfo.Id }, weatherInfo);
        }

        // DELETE: api/weather/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeatherInfo>> DeleteWeatherInfo(int id)
        {
            var weatherInfo = await _context.WeatherInfo.FindAsync(id);
            if (weatherInfo == null)
            {
                return NotFound();
            }

            _context.WeatherInfo.Remove(weatherInfo);
            await _context.SaveChangesAsync();

            return weatherInfo;
        }

        private bool WeatherInfoExists(int id)
        {
            return _context.WeatherInfo.Any(e => e.Id == id);
        }
    }
}
