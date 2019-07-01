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

        public void AddCity(City city)
        {
            var existingCity = _context.Cities.Find(city.Id);
            if(existingCity == null)
            {
                _context.Cities.Add(city);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("City with that ID already exists.");
            }
        }

        public void UpdateCity(City updatedCity)
        {
            var existingCity = _context.Cities.Find(updatedCity.Id);
            if (existingCity != null)
            {
                existingCity.Name = updatedCity.Name;
                existingCity.District = updatedCity.District;
                existingCity.Population = updatedCity.Population;
                existingCity.CountryCode = updatedCity.CountryCode;

                _context.Entry(existingCity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("City with that ID doesn't exist.");
            }
        }

        public void DeleteCity(int cityID)
        {
            var existingCity = _context.Cities.Find(cityID);
            if (existingCity != null)
            {
                _context.Cities.Remove(existingCity);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("City with that ID doesn't exist.");
            }
        }

        public List<City> FindCitiesByCountryCode(string countryCode)
        {
            var query = _context.Cities.AsQueryable();
            try
            {
                return query.Where(x => x.CountryCode == countryCode).ToList();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public List<City> FindCitiesByName(string name)
        {
            var query = _context.Cities.AsQueryable();
            try
            {
                return query.Where(x => x.Name == name).ToList();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
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
