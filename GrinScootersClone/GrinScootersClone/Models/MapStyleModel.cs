using Newtonsoft.Json;

namespace GrinScootersClone.Models
{
    public class MapStyleModel
    {
        [JsonProperty("style")]
        public string MapStyle { get; set; }
    }
}
