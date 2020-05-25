using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tzunami.Services.Documentum.Models
{
    public class DocumentumSystemInfo
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("properties")]
        public DocumentumSystemInfoProperty Properties { get; set; }

        [JsonProperty("links")]
        public IList<DocumentumLink> Links { get; set; }
    }



}
