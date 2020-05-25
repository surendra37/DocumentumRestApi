using Newtonsoft.Json;

namespace Emc.Documentum.Rest.Models
{
    public class DocumentumSystemInfoProperty
    {

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("product_version")]
        public string ProductVersion { get; set; }

        [JsonProperty("major")]
        public string Major { get; set; }

        [JsonProperty("minor")]
        public string Minor { get; set; }

        [JsonProperty("build_number")]
        public string BuildNumber { get; set; }

        [JsonProperty("revision_number")]
        public string RevisionNumber { get; set; }
    }
}