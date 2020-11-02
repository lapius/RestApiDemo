using Microsoft.EntityFrameworkCore;
using RestDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestDemo.Contexts
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<WeatherInfo> WeatherInfo { get; set; }
    }
}
