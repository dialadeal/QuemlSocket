/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// EndUserResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Trusthub.V1
{

    public class EndUserResource : Resource
    {
        private static Request BuildCreateRequest(CreateEndUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trusthub,
                "/v1/EndUsers",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Create a new End User.
        /// </summary>
        /// <param name="options"> Create EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static EndUserResource Create(CreateEndUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Create a new End User.
        /// </summary>
        /// <param name="options"> Create EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<EndUserResource> CreateAsync(CreateEndUserOptions options,
                                                                                     ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Create a new End User.
        /// </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="type"> The type of end user of the Bundle resource </param>
        /// <param name="attributes"> The set of parameters that compose the End User resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static EndUserResource Create(string friendlyName,
                                             string type,
                                             object attributes = null,
                                             ITwilioRestClient client = null)
        {
            var options = new CreateEndUserOptions(friendlyName, type){Attributes = attributes};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Create a new End User.
        /// </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="type"> The type of end user of the Bundle resource </param>
        /// <param name="attributes"> The set of parameters that compose the End User resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<EndUserResource> CreateAsync(string friendlyName,
                                                                                     string type,
                                                                                     object attributes = null,
                                                                                     ITwilioRestClient client = null)
        {
            var options = new CreateEndUserOptions(friendlyName, type){Attributes = attributes};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadEndUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trusthub,
                "/v1/EndUsers",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Retrieve a list of all End User for an account.
        /// </summary>
        /// <param name="options"> Read EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static ResourceSet<EndUserResource> Read(ReadEndUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<EndUserResource>.FromJson("results", response.Content);
            return new ResourceSet<EndUserResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all End User for an account.
        /// </summary>
        /// <param name="options"> Read EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EndUserResource>> ReadAsync(ReadEndUserOptions options,
                                                                                                ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<EndUserResource>.FromJson("results", response.Content);
            return new ResourceSet<EndUserResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of all End User for an account.
        /// </summary>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static ResourceSet<EndUserResource> Read(int? pageSize = null,
                                                        long? limit = null,
                                                        ITwilioRestClient client = null)
        {
            var options = new ReadEndUserOptions(){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all End User for an account.
        /// </summary>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EndUserResource>> ReadAsync(int? pageSize = null,
                                                                                                long? limit = null,
                                                                                                ITwilioRestClient client = null)
        {
            var options = new ReadEndUserOptions(){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<EndUserResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<EndUserResource>.FromJson("results", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<EndUserResource> NextPage(Page<EndUserResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Trusthub)
            );

            var response = client.Request(request);
            return Page<EndUserResource>.FromJson("results", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<EndUserResource> PreviousPage(Page<EndUserResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Trusthub)
            );

            var response = client.Request(request);
            return Page<EndUserResource>.FromJson("results", response.Content);
        }

        private static Request BuildFetchRequest(FetchEndUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trusthub,
                "/v1/EndUsers/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Fetch specific End User Instance.
        /// </summary>
        /// <param name="options"> Fetch EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static EndUserResource Fetch(FetchEndUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch specific End User Instance.
        /// </summary>
        /// <param name="options"> Fetch EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<EndUserResource> FetchAsync(FetchEndUserOptions options,
                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch specific End User Instance.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static EndUserResource Fetch(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchEndUserOptions(pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch specific End User Instance.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<EndUserResource> FetchAsync(string pathSid,
                                                                                    ITwilioRestClient client = null)
        {
            var options = new FetchEndUserOptions(pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateEndUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trusthub,
                "/v1/EndUsers/" + options.PathSid + "",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Update an existing End User.
        /// </summary>
        /// <param name="options"> Update EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static EndUserResource Update(UpdateEndUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Update an existing End User.
        /// </summary>
        /// <param name="options"> Update EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<EndUserResource> UpdateAsync(UpdateEndUserOptions options,
                                                                                     ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Update an existing End User.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="attributes"> The set of parameters that compose the End User resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static EndUserResource Update(string pathSid,
                                             string friendlyName = null,
                                             object attributes = null,
                                             ITwilioRestClient client = null)
        {
            var options = new UpdateEndUserOptions(pathSid){FriendlyName = friendlyName, Attributes = attributes};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Update an existing End User.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="attributes"> The set of parameters that compose the End User resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<EndUserResource> UpdateAsync(string pathSid,
                                                                                     string friendlyName = null,
                                                                                     object attributes = null,
                                                                                     ITwilioRestClient client = null)
        {
            var options = new UpdateEndUserOptions(pathSid){FriendlyName = friendlyName, Attributes = attributes};
            return await UpdateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteEndUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Trusthub,
                "/v1/EndUsers/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Delete a specific End User.
        /// </summary>
        /// <param name="options"> Delete EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static bool Delete(DeleteEndUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Delete a specific End User.
        /// </summary>
        /// <param name="options"> Delete EndUser parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteEndUserOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Delete a specific End User.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EndUser </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteEndUserOptions(pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Delete a specific End User.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EndUser </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteEndUserOptions(pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a EndUserResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> EndUserResource object represented by the provided JSON </returns>
        public static EndUserResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<EndUserResource>(json);
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
        /// The SID of the Account that created the resource
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The string that you assigned to describe the resource
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The type of end user of the Bundle resource
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }
        /// <summary>
        /// The set of parameters that compose the End Users resource
        /// </summary>
        [JsonProperty("attributes")]
        public object Attributes { get; private set; }
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
        /// The absolute URL of the End User resource
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private EndUserResource()
        {

        }
    }

}