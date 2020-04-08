using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrinScootersClone.Models
{
    public class MapStyleModel
    {
        [JsonProperty("style")]
        public string MapStyle { get; set; }
    }
}
