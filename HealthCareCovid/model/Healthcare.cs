using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareCovid.model
{
    public class Healthcare
    {
        public int healthcareid { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public bool? vaccineavailability { get; set; }
        public bool? testavailability { get; set; }
        public Map map { get; set; }
    }
}
