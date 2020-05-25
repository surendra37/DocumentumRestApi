using Newtonsoft.Json;

namespace Tzunami.Services.Documentum.Models
{
    public class DocumentumRepositories : PageResult<RepositoryEntry>
    {

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
