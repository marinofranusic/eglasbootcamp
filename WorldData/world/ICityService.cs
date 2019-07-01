using System;
using System.Collections.Generic;
using System.Text;

namespace WorldData.world
{
    interface ICityService
    {
        List<City> GetCities();
        City GetCity(int id);
        void AddCity(City city);
        void UpdateCity(City updatedCity);
        void DeleteCity(int cityID);
        List<City> FindCitiesByName(string name);
        List<City> FindCitiesByCountryCode(string countryCode);
    }
}
