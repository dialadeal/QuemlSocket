/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// ItemAssignmentResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Numbers.V2.RegulatoryCompliance.Bundle
{

    public class ItemAssignmentResource : Resource
    {
        private static Request BuildCreateRequest(CreateItemAssignmentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Numbers,
                "/v2/RegulatoryCompliance/Bundles/" + options.PathBundleSid + "/ItemAssignments",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Create a new Assigned Item.
        /// </summary>
        /// <param name="options"> Create ItemAssignment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ItemAssignment </returns>
        public static ItemAssignmentResource Create(CreateItemAssignmentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Create a new Assigned Item.
        /// </summary>
        /// <param name="options"> Create ItemAssignment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ItemAssignment </returns>
        public static async System.Threading.Tasks.Task<ItemAssignmentResource> CreateAsync(CreateItemAssignmentOptions options,
                                                                                            ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Create a new Assigned Item.
        /// </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the resource. </param>
        /// <param name="objectSid"> The sid of an object bag </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ItemAssignment </returns>
        public static ItemAssignmentResource Create(string pathBundleSid, string objectSid, ITwilioRestClient client = null)
        {
            var options = new CreateItemAssignmentOptions(pathBundleSid, objectSid);
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Create a new Assigned Item.
        /// </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the resource. </param>
        /// <param name="objectSid"> The sid of an object bag </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ItemAssignment </returns>
        public static async System.Threading.Tasks.Task<ItemAssignmentResource> CreateAsync(string pathBundleSid,
                                                                                            string objectSid,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new CreateItemAssignmentOptions(pathBundleSid, objectSid);
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadItemAssignmentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                "/v2/RegulatoryCompliance/Bundles/" + options.PathBundleSid + "/ItemAssignments",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Retrieve a list of all Assigned Items for an account.
        /// </summary>
        /// <param name="options"> Read ItemAssignment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ItemAssignment </returns>
        public static ResourceSet<ItemAssignmentResource> Read(ReadItemAssignmentOptions options,
                                                               ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<ItemAssignmentResource>.FromJson("results", response.Content);
            return new ResourceSet<ItemAssignmentResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Assigned Items for an account.
        /// </summary>
        /// <param name="options"> Read ItemAssignment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ItemAssignment </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ItemAssignmentResource>> ReadAsync(ReadItemAssignmentOptions options,
                                                                                                       ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ItemAssignmentResource>.FromJson("results", response.Content);
            return new ResourceSet<ItemAssignmentResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of all Assigned Items for an account.
        /// </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the resource. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ItemAssignment </returns>
        public static ResourceSet<ItemAssignmentResource> Read(string pathBundleSid,
                                                               int? pageSize = null,
                                                               long? limit = null,
                                                               ITwilioRestClient client = null)
        {
            var options = new ReadItemAssignmentOptions(pathBundleSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Assigned Items for an account.
        /// </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the resource. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ItemAssignment </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ItemAssignmentResource>> ReadAsync(string pathBundleSid,
                                                                                                       int? pageSize = null,
                                                                                                       long? limit = null,
                                                                                                       ITwilioRestClient client = null)
        {
            var options = new ReadItemAssignmentOptions(pathBundleSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ItemAssignmentResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ItemAssignmentResource>.FromJson("results", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ItemAssignmentResource> NextPage(Page<ItemAssignmentResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Numbers)
            );

            var response = client.Request(request);
            return Page<ItemAssignmentResource>.FromJson("results", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ItemAssignmentResource> PreviousPage(Page<ItemAssignmentResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Numbers)
            );

            var response = client.Request(request);
            return Page<ItemAssignmentResource>.FromJson("results", response.Content);
        }

        private static Request BuildFetchRequest(FetchItemAssignmentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                "/v2/RegulatoryCompliance/Bundles/" + options.PathBundleSid + "/ItemAssignments/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Fetch specific Assigned Item Instance.
        /// </summary>
        /// <param name="options"> Fetch ItemAssignment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ItemAssignment </returns>
        public static ItemAssignmentResource Fetch(FetchItemAssignmentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch specific Assigned Item Instance.
        /// </summary>
        /// <param name="options"> Fetch ItemAssignment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ItemAssignment </returns>
        public static async System.Threading.Tasks.Task<ItemAssignmentResource> FetchAsync(FetchItemAssignmentOptions options,
                                                                                           ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch specific Assigned Item Instance.
        /// </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the resource. </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ItemAssignment </returns>
        public static ItemAssignmentResource Fetch(string pathBundleSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchItemAssignmentOptions(pathBundleSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch specific Assigned Item Instance.
        /// </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the resource. </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ItemAssignment </returns>
        public static async System.Threading.Tasks.Task<ItemAssignmentResource> FetchAsync(string pathBundleSid,
                                                                                           string pathSid,
                                                                                           ITwilioRestClient client = null)
        {
            var options = new FetchItemAssignmentOptions(pathBundleSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteItemAssignmentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Numbers,
                "/v2/RegulatoryCompliance/Bundles/" + options.PathBundleSid + "/ItemAssignments/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Remove an Assignment Item Instance.
        /// </summary>
        /// <param name="options"> Delete ItemAssignment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ItemAssignment </returns>
        public static bool Delete(DeleteItemAssignmentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Remove an Assignment Item Instance.
        /// </summary>
        /// <param name="options"> Delete ItemAssignment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ItemAssignment </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteItemAssignmentOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Remove an Assignment Item Instance.
        /// </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the resource. </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ItemAssignment </returns>
        public static bool Delete(string pathBundleSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteItemAssignmentOptions(pathBundleSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Remove an Assignment Item Instance.
        /// </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the resource. </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ItemAssignment </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathBundleSid,
                                                                          string pathSid,
                                                                          ITwilioRestClient client = null)
        {
            var options = new DeleteItemAssignmentOptions(pathBundleSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a ItemAssignmentResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ItemAssignmentResource object represented by the provided JSON </returns>
        public static ItemAssignmentResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ItemAssignmentResource>(json);
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
        /// The unique string that identifies the Bundle resource.
        /// </summary>
        [JsonProperty("bundle_sid")]
        public string BundleSid { get; private set; }
        /// <summary>
        /// The SID of the Account that created the resource
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The sid of an object bag
        /// </summary>
        [JsonProperty("object_sid")]
        public string ObjectSid { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The absolute URL of the Identity resource
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private ItemAssignmentResource()
        {

        }
    }

}