using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestDemo.Repository;

namespace RestDemo.Interfaces
{
    public interface IWeatherRepository<T>
    {
        IEnumerable<T> GetAllWeathers();
    }
}
