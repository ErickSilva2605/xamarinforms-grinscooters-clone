using GrinScootersClone.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrinScootersClone.Models
{
    public class MenuModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("type")]
        public MenuTypeEnum Type { get; set; }
    }
}
