/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// MemberResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1.Service.Channel
{

    public class MemberResource : Resource
    {
        private static Request BuildFetchRequest(FetchMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Members/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Fetch(FetchMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<MemberResource> FetchAsync(FetchMemberOptions options,
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
        /// <param name="pathServiceSid"> The SID of the Service to fetch the resource from </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the member belongs to </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Fetch(string pathServiceSid,
                                           string pathChannelSid,
                                           string pathSid,
                                           ITwilioRestClient client = null)
        {
            var options = new FetchMemberOptions(pathServiceSid, pathChannelSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the resource from </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the member belongs to </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<MemberResource> FetchAsync(string pathServiceSid,
                                                                                   string pathChannelSid,
                                                                                   string pathSid,
                                                                                   ITwilioRestClient client = null)
        {
            var options = new FetchMemberOptions(pathServiceSid, pathChannelSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildCreateRequest(CreateMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Members",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Create(CreateMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<MemberResource> CreateAsync(CreateMemberOptions options,
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
        /// <param name="pathServiceSid"> The SID of the Service to create the resource under </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the new member belongs to </param>
        /// <param name="identity"> The `identity` value that identifies the new resource's User </param>
        /// <param name="roleSid"> The SID of the Role to assign to the member </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Create(string pathServiceSid,
                                            string pathChannelSid,
                                            string identity,
                                            string roleSid = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateMemberOptions(pathServiceSid, pathChannelSid, identity){RoleSid = roleSid};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to create the resource under </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the new member belongs to </param>
        /// <param name="identity"> The `identity` value that identifies the new resource's User </param>
        /// <param name="roleSid"> The SID of the Role to assign to the member </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<MemberResource> CreateAsync(string pathServiceSid,
                                                                                    string pathChannelSid,
                                                                                    string identity,
                                                                                    string roleSid = null,
                                                                                    ITwilioRestClient client = null)
        {
            var options = new CreateMemberOptions(pathServiceSid, pathChannelSid, identity){RoleSid = roleSid};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Members",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// read
        /// </summary>
        /// <param name="options"> Read Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static ResourceSet<MemberResource> Read(ReadMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<MemberResource>.FromJson("members", response.Content);
            return new ResourceSet<MemberResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        /// <param name="options"> Read Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<MemberResource>> ReadAsync(ReadMemberOptions options,
                                                                                               ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<MemberResource>.FromJson("members", response.Content);
            return new ResourceSet<MemberResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to read the resources from </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the member belongs to </param>
        /// <param name="identity"> The `identity` value of the resources to read </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static ResourceSet<MemberResource> Read(string pathServiceSid,
                                                       string pathChannelSid,
                                                       List<string> identity = null,
                                                       int? pageSize = null,
                                                       long? limit = null,
                                                       ITwilioRestClient client = null)
        {
            var options = new ReadMemberOptions(pathServiceSid, pathChannelSid){Identity = identity, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to read the resources from </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the member belongs to </param>
        /// <param name="identity"> The `identity` value of the resources to read </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<MemberResource>> ReadAsync(string pathServiceSid,
                                                                                               string pathChannelSid,
                                                                                               List<string> identity = null,
                                                                                               int? pageSize = null,
                                                                                               long? limit = null,
                                                                                               ITwilioRestClient client = null)
        {
            var options = new ReadMemberOptions(pathServiceSid, pathChannelSid){Identity = identity, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<MemberResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<MemberResource>.FromJson("members", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<MemberResource> NextPage(Page<MemberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Chat)
            );

            var response = client.Request(request);
            return Page<MemberResource>.FromJson("members", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<MemberResource> PreviousPage(Page<MemberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Chat)
            );

            var response = client.Request(request);
            return Page<MemberResource>.FromJson("members", response.Content);
        }

        private static Request BuildDeleteRequest(DeleteMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Chat,
                "/v1/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Members/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="options"> Delete Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static bool Delete(DeleteMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="options"> Delete Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteMemberOptions options,
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
        /// <param name="pathServiceSid"> The SID of the Service to delete the resource from </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the message to delete belongs to </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static bool Delete(string pathServiceSid,
                                  string pathChannelSid,
                                  string pathSid,
                                  ITwilioRestClient client = null)
        {
            var options = new DeleteMemberOptions(pathServiceSid, pathChannelSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to delete the resource from </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the message to delete belongs to </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid,
                                                                          string pathChannelSid,
                                                                          string pathSid,
                                                                          ITwilioRestClient client = null)
        {
            var options = new DeleteMemberOptions(pathServiceSid, pathChannelSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Members/" + options.PathSid + "",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Update(UpdateMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<MemberResource> UpdateAsync(UpdateMemberOptions options,
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
        /// <param name="pathServiceSid"> The SID of the Service to create the resource under </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the member to update belongs to </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="roleSid"> The SID of the Role to assign to the member </param>
        /// <param name="lastConsumedMessageIndex"> The index of the last consumed Message for the Channel for the Member
        ///                                </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Update(string pathServiceSid,
                                            string pathChannelSid,
                                            string pathSid,
                                            string roleSid = null,
                                            int? lastConsumedMessageIndex = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateMemberOptions(pathServiceSid, pathChannelSid, pathSid){RoleSid = roleSid, LastConsumedMessageIndex = lastConsumedMessageIndex};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to create the resource under </param>
        /// <param name="pathChannelSid"> The unique ID of the channel the member to update belongs to </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="roleSid"> The SID of the Role to assign to the member </param>
        /// <param name="lastConsumedMessageIndex"> The index of the last consumed Message for the Channel for the Member
        ///                                </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<MemberResource> UpdateAsync(string pathServiceSid,
                                                                                    string pathChannelSid,
                                                                                    string pathSid,
                                                                                    string roleSid = null,
                                                                                    int? lastConsumedMessageIndex = null,
                                                                                    ITwilioRestClient client = null)
        {
            var options = new UpdateMemberOptions(pathServiceSid, pathChannelSid, pathSid){RoleSid = roleSid, LastConsumedMessageIndex = lastConsumedMessageIndex};
            return await UpdateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a MemberResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MemberResource object represented by the provided JSON </returns>
        public static MemberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MemberResource>(json);
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
        /// The unique ID of the Channel for the member
        /// </summary>
        [JsonProperty("channel_sid")]
        public string ChannelSid { get; private set; }
        /// <summary>
        /// The SID of the Service that the resource is associated with
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// The string that identifies the resource's User
        /// </summary>
        [JsonProperty("identity")]
        public string Identity { get; private set; }
        /// <summary>
        /// The RFC 2822 date and time in GMT when the resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The RFC 2822 date and time in GMT when the resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The SID of the Role assigned to the member
        /// </summary>
        [JsonProperty("role_sid")]
        public string RoleSid { get; private set; }
        /// <summary>
        /// The index of the last Message that the Member has read within the Channel
        /// </summary>
        [JsonProperty("last_consumed_message_index")]
        public int? LastConsumedMessageIndex { get; private set; }
        /// <summary>
        /// The ISO 8601 based timestamp string that represents the date-time of the last Message read event for the Member within the Channel
        /// </summary>
        [JsonProperty("last_consumption_timestamp")]
        public DateTime? LastConsumptionTimestamp { get; private set; }
        /// <summary>
        /// The absolute URL of the Member resource
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private MemberResource()
        {

        }
    }

}