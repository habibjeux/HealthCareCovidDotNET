using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthCareCovid.model
{
    public class Map
    {
        public int mapid { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }
}
