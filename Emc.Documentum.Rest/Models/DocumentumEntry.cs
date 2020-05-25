using Newtonsoft.Json;

namespace Emc.Documentum.Rest.Models
{
    public class DocumentumEntry : DocumentumFeed
    {

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("content")]
        public DocumentumContent Content { get; set; }
    }
}