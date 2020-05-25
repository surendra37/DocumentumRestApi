using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Emc.Documentum.Rest.Models
{
    public class DocumentumFeed
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("author")]
        public IList<DocumentumEntity> Author { get; set; }


        [JsonProperty("links")]
        public IList<DocumentumLink> Links { get; set; }
    }
}
