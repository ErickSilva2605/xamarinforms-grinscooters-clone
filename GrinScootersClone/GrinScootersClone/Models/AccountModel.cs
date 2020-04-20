using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrinScootersClone.Models
{
    public class AccountModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }
    }
}
