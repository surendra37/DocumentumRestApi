using Newtonsoft.Json;

namespace Emc.Documentum.Rest.Models
{

    public class RepositoryContent
    {

        [JsonProperty("content-type")]
        public string ContentType { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }
    }
}