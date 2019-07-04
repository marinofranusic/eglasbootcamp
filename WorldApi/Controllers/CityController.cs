using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldData.world;

namespace WorldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly worldContext _context;
        private readonly ICityService _cityService;

        public CityController(worldContext context)
        {
            _context = context;
            _cityService = new CityService(context);
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<City>> GetCities()
        {
            return _cityService.GetCities();
        }

        [HttpGet("alive")]
        public ActionResult<string> IsAlive()
        {
            return "OK";
        }

        [HttpGet("{id}")]
        public ActionResult<City> GetCity(int id)
        {
            return _cityService.GetCity(id);
        }

        [HttpGet("byname/{value}")]
        public ActionResult<IEnumerable<City>> CitiesByName(string value)
        {
            return _cityService.FindCitiesByName(value);
        }

        [HttpGet("bycode/{value}")]
        public ActionResult<IEnumerable<City>> CitiesByCountryCode(string value)
        {
            return _cityService.FindCitiesByCountryCode(value);
        }

        [HttpPost]
        public ActionResult<City> PostCity(City city)
        {
            _cityService.AddCity(city);
            return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }

        [HttpPut]
        public ActionResult<City> PutCity(City city)
        {
            _cityService.UpdateCity(city);
            return AcceptedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCity(int id)
        {
            _cityService.DeleteCity(id);
            return NoContent();
        }
    }
}