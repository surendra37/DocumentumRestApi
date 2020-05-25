using Newtonsoft.Json;
using System.Collections.Generic;

namespace Emc.Documentum.Rest.Models
{
    public class RepositoryEntry
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("content")]
        public RepositoryContent Content { get; set; }

        [JsonProperty("links")]
        public IList<DocumentumLink> Links { get; set; }
    }
}