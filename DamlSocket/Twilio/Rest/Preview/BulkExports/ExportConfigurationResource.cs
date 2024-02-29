/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
/// currently do not have developer preview access, please contact help@twilio.com.
///
/// ExportConfigurationResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.BulkExports
{

    public class ExportConfigurationResource : Resource
    {
        private static Request BuildFetchRequest(FetchExportConfigurationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/BulkExports/Exports/" + options.PathResourceType + "/Configuration",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Fetch a specific Export Configuration.
        /// </summary>
        /// <param name="options"> Fetch ExportConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ExportConfiguration </returns>
        public static ExportConfigurationResource Fetch(FetchExportConfigurationOptions options,
                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Export Configuration.
        /// </summary>
        /// <param name="options"> Fetch ExportConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ExportConfiguration </returns>
        public static async System.Threading.Tasks.Task<ExportConfigurationResource> FetchAsync(FetchExportConfigurationOptions options,
                                                                                                ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch a specific Export Configuration.
        /// </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ExportConfiguration </returns>
        public static ExportConfigurationResource Fetch(string pathResourceType, ITwilioRestClient client = null)
        {
            var options = new FetchExportConfigurationOptions(pathResourceType);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Export Configuration.
        /// </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ExportConfiguration </returns>
        public static async System.Threading.Tasks.Task<ExportConfigurationResource> FetchAsync(string pathResourceType,
                                                                                                ITwilioRestClient client = null)
        {
            var options = new FetchExportConfigurationOptions(pathResourceType);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateExportConfigurationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/BulkExports/Exports/" + options.PathResourceType + "/Configuration",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Update a specific Export Configuration.
        /// </summary>
        /// <param name="options"> Update ExportConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ExportConfiguration </returns>
        public static ExportConfigurationResource Update(UpdateExportConfigurationOptions options,
                                                         ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Update a specific Export Configuration.
        /// </summary>
        /// <param name="options"> Update ExportConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ExportConfiguration </returns>
        public static async System.Threading.Tasks.Task<ExportConfigurationResource> UpdateAsync(UpdateExportConfigurationOptions options,
                                                                                                 ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Update a specific Export Configuration.
        /// </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        /// <param name="enabled"> Whether files are automatically generated </param>
        /// <param name="webhookUrl"> URL targeted at export </param>
        /// <param name="webhookMethod"> Whether to GET or POST to the webhook url </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ExportConfiguration </returns>
        public static ExportConfigurationResource Update(string pathResourceType,
                                                         bool? enabled = null,
                                                         Uri webhookUrl = null,
                                                         string webhookMethod = null,
                                                         ITwilioRestClient client = null)
        {
            var options = new UpdateExportConfigurationOptions(pathResourceType){Enabled = enabled, WebhookUrl = webhookUrl, WebhookMethod = webhookMethod};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Update a specific Export Configuration.
        /// </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        /// <param name="enabled"> Whether files are automatically generated </param>
        /// <param name="webhookUrl"> URL targeted at export </param>
        /// <param name="webhookMethod"> Whether to GET or POST to the webhook url </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ExportConfiguration </returns>
        public static async System.Threading.Tasks.Task<ExportConfigurationResource> UpdateAsync(string pathResourceType,
                                                                                                 bool? enabled = null,
                                                                                                 Uri webhookUrl = null,
                                                                                                 string webhookMethod = null,
                                                                                                 ITwilioRestClient client = null)
        {
            var options = new UpdateExportConfigurationOptions(pathResourceType){Enabled = enabled, WebhookUrl = webhookUrl, WebhookMethod = webhookMethod};
            return await UpdateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a ExportConfigurationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ExportConfigurationResource object represented by the provided JSON </returns>
        public static ExportConfigurationResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ExportConfigurationResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// Whether files are automatically generated
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; private set; }
        /// <summary>
        /// URL targeted at export
        /// </summary>
        [JsonProperty("webhook_url")]
        public Uri WebhookUrl { get; private set; }
        /// <summary>
        /// Whether to GET or POST to the webhook url
        /// </summary>
        [JsonProperty("webhook_method")]
        public string WebhookMethod { get; private set; }
        /// <summary>
        /// The type of communication – Messages, Calls, Conferences, and Participants
        /// </summary>
        [JsonProperty("resource_type")]
        public string ResourceType { get; private set; }
        /// <summary>
        /// The URL of this resource.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private ExportConfigurationResource()
        {

        }
    }

}