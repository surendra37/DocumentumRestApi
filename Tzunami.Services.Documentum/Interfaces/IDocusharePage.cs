using System.Collections.Generic;
using Tzunami.Services.Documentum.Models;

namespace Tzunami.Services.Documentum.Interfaces
{
    public interface IDocumentumPage
    {
        IList<DocumentumLink> Links { get; set; }
        string NextPageLink { get; }
        string PreviousPageLink { get; }
        string FirstPageLink { get; }
    }
}