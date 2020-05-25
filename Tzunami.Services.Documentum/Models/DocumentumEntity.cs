using Newtonsoft.Json;

namespace Tzunami.Services.Documentum.Models
{
    /// <summary>
    /// Users/Groups
    /// </summary>
    public class DocumentumEntity
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}