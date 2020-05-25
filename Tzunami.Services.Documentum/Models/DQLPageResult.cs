using Newtonsoft.Json;

namespace Tzunami.Services.Documentum.Models
{

    public class DQLPageResult : PageResult<DocumentumEntry>
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("items-per-page")]
        public int ItemsPerPage { get; set; }
    }
}