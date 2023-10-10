using System;

namespace HealthCareCovid.model
{
    public class Appointment
    {
        public int appointmentid { get; set; }
        public DateTime date { get; set; }
        public string doseType { get; set; }
        public string notes { get; set; }
        public Healthcare healthcare { get; set; }
    }
}
