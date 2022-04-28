using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
    }
}
