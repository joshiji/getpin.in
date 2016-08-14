using System;

namespace GetPin.Models
{
    public class PinCode
    {
        public Guid PinCodeId { get; set; }

        public String PinCodeNumber { get; set; }

        public Country Country { get; set; }

    }
}
