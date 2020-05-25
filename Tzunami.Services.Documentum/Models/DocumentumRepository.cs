using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tzunami.Services.Documentum.Models
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
