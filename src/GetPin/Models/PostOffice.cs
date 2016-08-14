using System;

namespace GetPin.Models
{
    public enum DeliveryStatus 
    {
        Delivery,
        NonDelivery
    }

    public enum OfficeType
    {

    }
    public class PostOffice
    {
        public Guid PostOfficeId { get; set; }

        public String PostOfficeName { get; set; }

        public PinCode PinCode { get; set; }

        public OfficeType OfficeType { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; }

        public Division Division { get; set; }

        public Region Region { get; set; }

        public State Circle { get; set; }

        public Taluk Taluk { get; set; }

        public District District { get; set; }

        public State State { get; set; }

        public string Phone { get; set; }

        public Office RelatedSubOffice { get; set; }

        public Office RelatedHeadOffice { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }
    }
}