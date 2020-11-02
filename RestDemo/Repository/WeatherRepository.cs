using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestDemo.Contexts;
using RestDemo.Entities;
using RestDemo.Interfaces;

namespace RestDemo.Repository
{
    public class WeatherRepository: IWeatherRepository<WeatherInfo>
    {
        readonly WeatherContext _weatherContext;

        public WeatherRepository(WeatherContext context)
        {
            _weatherContext = context;
        }

        public IEnumerable<WeatherInfo> GetAllWeathers()
        {
            return _weatherContext.WeatherInfo.ToList();
        }
    }
}
