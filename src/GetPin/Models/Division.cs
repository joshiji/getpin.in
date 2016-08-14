
using System;

namespace GetPin.Models
{
    public class Division
    {
        public Guid DivisionId { get; set; }

        public String DivisionName { get; set; }

        public Region Region { get; set; }
    }
}