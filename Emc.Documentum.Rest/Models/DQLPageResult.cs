using Newtonsoft.Json;

namespace Emc.Documentum.Rest.Models
{

    public class DQLPageResult : PageResult<DocumentumEntry>
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("items-per-page")]
        public int ItemsPerPage { get; set; }
    }
}