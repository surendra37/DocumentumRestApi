using Newtonsoft.Json;
using System.Collections.Generic;

namespace Emc.Documentum.Rest.Models
{
    public class DocumentumRepository
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("servers")]
        public IList<DocumentumServer> Servers { get; set; }

        [JsonProperty("links")]
        public IList<DocumentumLink> Links { get; set; }
    }



}
