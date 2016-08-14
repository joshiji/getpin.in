using System;

namespace GetPin.Models
{
    public class Taluk
    {
        public Guid TalukId { get; set; }

        public String TalukName { get; set; }

        public District District { get; set; }
    }
}