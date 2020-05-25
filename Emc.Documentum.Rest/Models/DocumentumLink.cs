using Newtonsoft.Json;

namespace Emc.Documentum.Rest.Models
{

    public class DocumentumLink
    {

        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("hreftemplate")]
        public string Hreftemplate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}