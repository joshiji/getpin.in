using System;

namespace GetPin.Models
{
    public class District
    {
        public Guid DistrictId { get; set; }

        public String DistrictName { get; set; }

        public State State { get; set; }
    }
}