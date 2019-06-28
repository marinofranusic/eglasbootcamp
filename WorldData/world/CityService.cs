using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldData.world
{
    public class CityService : ICityService
    {
        private worldContext _context;

        public CityService(worldContext ctx)
        {
            _context = ctx;
        }

        public List<City> GetCities()
        {
            return _context.Cities.ToList();
        }

        public City GetCity(int id)
        {
            var query = _context.Cities.AsQueryable();
            try
            {
                return query.SingleOrDefault(x => x.Id == id);
            }
            catch(InvalidOperationException ex)
            {
                return null;
            }
        }
    }
}
