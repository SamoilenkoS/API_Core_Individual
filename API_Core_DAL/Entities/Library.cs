using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Core_DAL.Entities
{
    public class Library : BaseEntity
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        [ForeignKey("City")]
        public Guid CityId { get; set; }
        public City City { get; set; }
        public string FullAddress { get; set; }
        public double DelayPrice { get; set; }
    }
}
