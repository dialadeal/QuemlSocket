﻿#if !NET35
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Twilio.Http
{
    /// <summary>
    /// Sample client to make HTTP requests
    /// </summary>
    public class SystemNetHttpClient : HttpClient
    {
#if NET451
        private string PlatVersion = " (.NET Framework 4.5.1+)";
#else
        private string PlatVersion = $" ({RuntimeInformation.FrameworkDescription})";
#endif

        private readonly System.Net.Http.HttpClient _httpClient;

        /// <summary>
        /// Create new HttpClient
        /// </summary>
        /// <param name="httpClient">HTTP client to use</param>
        public SystemNetHttpClient(System.Net.Http.HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new System.Net.Http.HttpClient(new HttpClientHandler() { AllowAutoRedirect = false });
        }

        /// <summary>
        /// Make a synchronous request
        /// </summary>
        /// <param name="request">Twilio request</param>
        /// <returns>Twilio response</returns>
        public override Response MakeRequest(Request request)
        {
            try
            {
                var task = MakeRequestAsync(request);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ae)
            {
                // Combine nested AggregateExceptions
                ae = ae.Flatten();
                throw ae.InnerExceptions[0];
            }
        }

        /// <summary>
        /// Make an asynchronous request
        /// </summary>
        /// <param name="request">Twilio response</param>
        /// <returns>Task that resolves to the response</returns>
        public override async Task<Response> MakeRequestAsync(Request request)
        {
            var httpRequest = BuildHttpRequest(request);
            if (!Equals(request.Method, HttpMethod.Get))
            {
                httpRequest.Content = new FormUrlEncodedContent(request.PostParams);
            }

            this.LastRequest = request;
            this.LastResponse = null;

            var httpResponse = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            var reader = new StreamReader(await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false));

            // Create and return a new Response. Keep a reference to the last
            // response for debugging, but don't return it as it may be shared
            // among threads.
            var response = new Response(httpResponse.StatusCode, await reader.ReadToEndAsync().ConfigureAwait(false), httpResponse.Headers);
            this.LastResponse = response;
            return response;
        }

        private HttpRequestMessage BuildHttpRequest(Request request)
        {
            var httpRequest = new HttpRequestMessage(
                new System.Net.Http.HttpMethod(request.Method.ToString()),
                request.ConstructUrl()
            );

            var authBytes = Authentication(request.Username, request.Password);
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", authBytes);

            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequest.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));

            var libraryVersion = "twilio-csharp/" + "5.73.0"+ PlatVersion;
            httpRequest.Headers.TryAddWithoutValidation("User-Agent", libraryVersion);

            foreach (var header in request.HeaderParams)
            {
                httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return httpRequest;
        }
    }
}
#endif
