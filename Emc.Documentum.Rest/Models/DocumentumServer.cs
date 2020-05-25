using Newtonsoft.Json;

namespace Emc.Documentum.Rest.Models
{
    public class DocumentumServer
    {

        [JsonProperty("docbroker")]
        public string Docbroker { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}