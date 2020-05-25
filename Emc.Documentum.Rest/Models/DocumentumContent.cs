using Newtonsoft.Json;
using System.Collections.Generic;

namespace Emc.Documentum.Rest.Models
{
    public class DocumentumContent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("properties")]
        public IDictionary<string, string> Properties { get; set; }

        [JsonProperty("links")]
        public IList<DocumentumLink> Links { get; set; }
    }



}
