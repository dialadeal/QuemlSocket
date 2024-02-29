/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// DocumentResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Sync.V1.Service
{

    public class DocumentResource : Resource
    {
        private static Request BuildFetchRequest(FetchDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Sync,
                "/v1/Services/" + options.PathServiceSid + "/Documents/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static DocumentResource Fetch(FetchDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<DocumentResource> FetchAsync(FetchDocumentOptions options,
                                                                                     ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service with the Document resource to fetch </param>
        /// <param name="pathSid"> The SID of the Document resource to fetch </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static DocumentResource Fetch(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchDocumentOptions(pathServiceSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service with the Document resource to fetch </param>
        /// <param name="pathSid"> The SID of the Document resource to fetch </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<DocumentResource> FetchAsync(string pathServiceSid,
                                                                                     string pathSid,
                                                                                     ITwilioRestClient client = null)
        {
            var options = new FetchDocumentOptions(pathServiceSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Sync,
                "/v1/Services/" + options.PathServiceSid + "/Documents/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="options"> Delete Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static bool Delete(DeleteDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="options"> Delete Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteDocumentOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service with the Document resource to delete </param>
        /// <param name="pathSid"> The SID of the Document resource to delete </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteDocumentOptions(pathServiceSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service with the Document resource to delete </param>
        /// <param name="pathSid"> The SID of the Document resource to delete </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid,
                                                                          string pathSid,
                                                                          ITwilioRestClient client = null)
        {
            var options = new DeleteDocumentOptions(pathServiceSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildCreateRequest(CreateDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Sync,
                "/v1/Services/" + options.PathServiceSid + "/Documents",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static DocumentResource Create(CreateDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<DocumentResource> CreateAsync(CreateDocumentOptions options,
                                                                                      ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// create
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service to associate the Document resource to create with </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the Sync Document </param>
        /// <param name="data"> A JSON string that represents an arbitrary, schema-less object that the Sync Document stores
        ///            </param>
        /// <param name="ttl"> How long, in seconds, before the Sync Document expires and is deleted </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static DocumentResource Create(string pathServiceSid,
                                              string uniqueName = null,
                                              object data = null,
                                              int? ttl = null,
                                              ITwilioRestClient client = null)
        {
            var options = new CreateDocumentOptions(pathServiceSid){UniqueName = uniqueName, Data = data, Ttl = ttl};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service to associate the Document resource to create with </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the Sync Document </param>
        /// <param name="data"> A JSON string that represents an arbitrary, schema-less object that the Sync Document stores
        ///            </param>
        /// <param name="ttl"> How long, in seconds, before the Sync Document expires and is deleted </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<DocumentResource> CreateAsync(string pathServiceSid,
                                                                                      string uniqueName = null,
                                                                                      object data = null,
                                                                                      int? ttl = null,
                                                                                      ITwilioRestClient client = null)
        {
            var options = new CreateDocumentOptions(pathServiceSid){UniqueName = uniqueName, Data = data, Ttl = ttl};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Sync,
                "/v1/Services/" + options.PathServiceSid + "/Documents",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// read
        /// </summary>
        /// <param name="options"> Read Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static ResourceSet<DocumentResource> Read(ReadDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<DocumentResource>.FromJson("documents", response.Content);
            return new ResourceSet<DocumentResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        /// <param name="options"> Read Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DocumentResource>> ReadAsync(ReadDocumentOptions options,
                                                                                                 ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<DocumentResource>.FromJson("documents", response.Content);
            return new ResourceSet<DocumentResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service with the Document resources to read </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static ResourceSet<DocumentResource> Read(string pathServiceSid,
                                                         int? pageSize = null,
                                                         long? limit = null,
                                                         ITwilioRestClient client = null)
        {
            var options = new ReadDocumentOptions(pathServiceSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service with the Document resources to read </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DocumentResource>> ReadAsync(string pathServiceSid,
                                                                                                 int? pageSize = null,
                                                                                                 long? limit = null,
                                                                                                 ITwilioRestClient client = null)
        {
            var options = new ReadDocumentOptions(pathServiceSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<DocumentResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<DocumentResource>.FromJson("documents", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<DocumentResource> NextPage(Page<DocumentResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Sync)
            );

            var response = client.Request(request);
            return Page<DocumentResource>.FromJson("documents", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<DocumentResource> PreviousPage(Page<DocumentResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Sync)
            );

            var response = client.Request(request);
            return Page<DocumentResource>.FromJson("documents", response.Content);
        }

        private static Request BuildUpdateRequest(UpdateDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Sync,
                "/v1/Services/" + options.PathServiceSid + "/Documents/" + options.PathSid + "",
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static DocumentResource Update(UpdateDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<DocumentResource> UpdateAsync(UpdateDocumentOptions options,
                                                                                      ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// update
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service with the Document resource to update </param>
        /// <param name="pathSid"> The SID of the Document resource to update </param>
        /// <param name="data"> A JSON string that represents an arbitrary, schema-less object that the Sync Document stores
        ///            </param>
        /// <param name="ttl"> How long, in seconds, before the Document resource expires and is deleted </param>
        /// <param name="ifMatch"> The If-Match HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns>
        public static DocumentResource Update(string pathServiceSid,
                                              string pathSid,
                                              object data = null,
                                              int? ttl = null,
                                              string ifMatch = null,
                                              ITwilioRestClient client = null)
        {
            var options = new UpdateDocumentOptions(pathServiceSid, pathSid){Data = data, Ttl = ttl, IfMatch = ifMatch};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Sync Service with the Document resource to update </param>
        /// <param name="pathSid"> The SID of the Document resource to update </param>
        /// <param name="data"> A JSON string that represents an arbitrary, schema-less object that the Sync Document stores
        ///            </param>
        /// <param name="ttl"> How long, in seconds, before the Document resource expires and is deleted </param>
        /// <param name="ifMatch"> The If-Match HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns>
        public static async System.Threading.Tasks.Task<DocumentResource> UpdateAsync(string pathServiceSid,
                                                                                      string pathSid,
                                                                                      object data = null,
                                                                                      int? ttl = null,
                                                                                      string ifMatch = null,
                                                                                      ITwilioRestClient client = null)
        {
            var options = new UpdateDocumentOptions(pathServiceSid, pathSid){Data = data, Ttl = ttl, IfMatch = ifMatch};
            return await UpdateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a DocumentResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DocumentResource object represented by the provided JSON </returns>
        public static DocumentResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DocumentResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The unique string that identifies the resource
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// An application-defined string that uniquely identifies the resource
        /// </summary>
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }
        /// <summary>
        /// The SID of the Account that created the resource
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The SID of the Sync Service that the resource is associated with
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// The absolute URL of the Document resource
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The URLs of resources related to the Sync Document
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
        /// <summary>
        /// The current revision of the Sync Document, represented by a string identifier
        /// </summary>
        [JsonProperty("revision")]
        public string Revision { get; private set; }
        /// <summary>
        /// An arbitrary, schema-less object that the Sync Document stores
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the Sync Document expires
        /// </summary>
        [JsonProperty("date_expires")]
        public DateTime? DateExpires { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The identity of the Sync Document's creator
        /// </summary>
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }

        private DocumentResource()
        {

        }
    }

}