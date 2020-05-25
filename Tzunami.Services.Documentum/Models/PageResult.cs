using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Tzunami.Services.Documentum.Interfaces;

namespace Tzunami.Services.Documentum.Models
{
    public abstract class PageResult<T> : DocumentumFeed, IDocumentumPage
    {
        [JsonProperty("entries")]
        public IList<T> Entries { get; set; }

        public string NextPageLink => Links.FirstOrDefault(link => link.Rel.Equals("next"))?.Href ?? string.Empty;
        public string PreviousPageLink => Links.FirstOrDefault(link => link.Rel.Equals("previous"))?.Href ?? string.Empty;
        public string FirstPageLink => Links.FirstOrDefault(link => link.Rel.Equals("first"))?.Href ?? string.Empty;
    }
}
