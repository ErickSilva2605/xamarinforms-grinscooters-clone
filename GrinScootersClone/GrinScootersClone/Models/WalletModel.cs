using Newtonsoft.Json;

namespace GrinScootersClone.Models
{
    public class WalletModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }
    }
}
