using Newtonsoft.Json;

namespace Emc.Documentum.Rest.Models
{
    public class DocumentumRepositories : PageResult<RepositoryEntry>
    {

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
