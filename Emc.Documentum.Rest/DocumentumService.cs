using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using Emc.Documentum.Rest.Models;
using Emc.Documentum.Rest.Constants;
using Emc.Documentum.Rest.Interfaces;

namespace Emc.Documentum.Rest
{
    public class DocumentumService
    {
        private readonly RestClient _mClient;
        public DocumentumService()
        {
            _mClient = new RestClient();
            _mClient.UseNewtonsoftJson();
            _mClient.AddDefaultHeader("Content-Type", "application/vnd.emc.documentum+json");
        }

        #region Unauthorized access
        /// <summary>
        /// Get the sytem info of the rest service
        /// </summary>
        /// <param name="url">Url endpoint of rest service</param>
        /// <returns>Rest service system information</returns>
        public DocumentumSystemInfo GetSystemInfo(string url)
        {
            var api = url.Trim() + ApiConstants.ProductInfo;
            var request = new RestRequest(api);
            var response = _mClient.Get<DocumentumSystemInfo>(request);
            return response.Data;
        }

        /// <summary>
        /// Get a list of all repositories
        /// </summary>
        /// <param name="url">Url of rest service. Example: http://{{host}}/dctm-rest</param>
        /// <returns></returns>
        public IEnumerable<RepositoryEntry> GetRepositories(string url)
        {
            var api = url.Trim() + ApiConstants.GetRepositories;
            var request = new RestRequest(api);
            EnableInlineContent(request, true);
            var response = _mClient.Get<DocumentumRepositories>(request);
            return response.Data.Entries;
        }

        /// <summary>
        /// Authenticate service
        /// </summary>
        /// <param name="url">Url of rest service. Example: http://{{host}}/dctm-rest</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="repo">Name of repo to authenticate</param>
        public void Authorize(string url, string username, string password, string repo)
        {
            var api = url.Trim('/') + ApiConstants.GetRepositories + "/" + repo;
            var request = new RestRequest(api);

            _mClient.Authenticator = new HttpBasicAuthenticator(username, password);
            var response = _mClient.Get<DocumentumRepositories>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new AuthenticationException();
            }
            _mClient.BaseUrl = new Uri(api);
        }
        #endregion


        #region Requires Authentication to be successful
        /// <summary>
        /// Get the information of current repository
        /// </summary>
        public DocumentumRepository GetCurrentRepository()
        {
            var request = new RestRequest();
            EnableLinksInResponse(request, false);

            var response = _mClient.Get<DocumentumRepository>(request);
            return response.Data;
        }

        public DocumentumCabinets GetCabinets()
        {
            var request = new RestRequest(ApiConstants.Cabinets);
            EnableInlineContent(request, true);

            var response = _mClient.Get<DocumentumCabinets>(request);
            return response.Data;
        }

        public DQLPageResult QueryDQL(string dql)
        {
            var request = new RestRequest();
            request.AddParameter("dql", dql);

            var response = _mClient.Get<DQLPageResult>(request);
            return response.Data;
        }

        /// <summary>
        /// Use dql to get entry data for all pages
        /// </summary>
        /// <param name="dql">DQL Query</param>
        /// <returns>List of pages</returns>
        public IEnumerable<DocumentumEntry> QueryDQLAll(string dql)
        {
            var request = new RestRequest();
            request.AddParameter("dql", dql);

            return AllPages<DQLPageResult>(request)
                .SelectMany(page => page.Entries);
        }

        #region Pagination
        /// <summary>
        /// All pages results
        /// </summary>
        /// <typeparam name="T">Type of page to create</typeparam>
        /// <param name="request">Initial rest request</param>
        /// <returns>List of all pages</returns>
        public IEnumerable<T> AllPages<T>(RestRequest request) where T : IDocumentumPage, new()
        {
            var response = _mClient.Get<T>(request);
            var page = response.Data;
            yield return page;

            while (true)
            {

                page = NextPage(page);
                if (page == null) yield break;

                yield return page;
            }
        }

        /// <summary>
        /// Get the next page
        /// </summary>
        /// <typeparam name="T">Must implement IDocumentumPage and creatable</typeparam>
        /// <param name="page">Current page</param>
        /// <returns>Next Page result</returns>
        public T NextPage<T>(T page) where T : IDocumentumPage, new()
        {
            if (page == null || string.IsNullOrEmpty(page.NextPageLink)) return default;

            var request = new RestRequest(page.NextPageLink);
            var response = _mClient.Get<T>(request);
            return response.Data;
        }

        /// <summary>
        /// Get the previous page
        /// </summary>
        /// <typeparam name="T">Must implement IDocumentumPage and creatable</typeparam>
        /// <param name="page">Current page</param>
        /// <returns>Previous Page result</returns>
        public T PreviousPage<T>(T page) where T : IDocumentumPage, new()
        {
            if (page == null || string.IsNullOrEmpty(page.PreviousPageLink)) return default;

            var request = new RestRequest(page.PreviousPageLink);
            var response = _mClient.Get<T>(request);
            return response.Data;
        }

        /// <summary>
        /// Get the first page
        /// </summary>
        /// <typeparam name="T">Must implement IDocumentumPage and creatable</typeparam>
        /// <param name="page">Current page</param>
        /// <returns>First Page result</returns>
        public T FirstPage<T>(T page) where T : IDocumentumPage, new()
        {
            if (page == null || string.IsNullOrEmpty(page.FirstPageLink)) return default;

            var request = new RestRequest(page.FirstPageLink);
            var response = _mClient.Get<T>(request);
            return response.Data;
        }
        #endregion 

        #endregion

        #region Helper methods
        /// <summary>
        /// If set the response will contain Links object otherwise not
        /// </summary>
        private static void EnableLinksInResponse(RestRequest request, bool value = false)
        {
            request.AddQueryParameter("links", value.ToString());
        }

        /// <summary>
        /// If set the response will inline content(expanded/not only link) otherwise not
        /// </summary>
        private static void EnableInlineContent(RestRequest request, bool value = false)
        {
            request.AddQueryParameter("inline", value.ToString());
        } 
        #endregion
    }
}
