using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrinScootersClone.Models
{
    public class PlaceModel
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
