using System;

namespace API_Core_BL.DTOs
{
    public class LibraryDto
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string FullAddress { get; set; }
        public double DelayPrice { get; set; }
        public Guid CityId { get; set; }
    }
}
