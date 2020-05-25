using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Emc.Documentum.Rest.Interfaces;

namespace Emc.Documentum.Rest.Models
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
