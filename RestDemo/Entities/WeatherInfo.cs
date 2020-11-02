using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestDemo.Entities
{
    [Table("WeatherInfo",Schema ="dbo")]
    public class WeatherInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float degrees { get; set; }

        [Required]
        public DateTime dateTime { get; set; }
    }
}
