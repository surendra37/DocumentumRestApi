using System.Collections.Generic;
using Emc.Documentum.Rest.Models;

namespace Emc.Documentum.Rest.Interfaces
{
    public interface IDocumentumPage
    {
        IList<DocumentumLink> Links { get; set; }
        string NextPageLink { get; }
        string PreviousPageLink { get; }
        string FirstPageLink { get; }
    }
}