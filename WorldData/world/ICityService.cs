using System;
using System.Collections.Generic;
using System.Text;

namespace WorldData.world
{
    interface ICityService
    {
        List<City> GetCities();
        City GetCity(int id);
    }
}
