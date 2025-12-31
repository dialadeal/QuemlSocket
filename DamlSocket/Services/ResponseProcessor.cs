using System;
using DamlSocket.Behaviors;

namespace DamlSocket.Services
{
    public static class ResponseProcessor
    {
        public static string ProcessResponse(string response, Request request)
        {
            if (string.IsNullOrEmpty(response))
            {
                return response;
            }

            // Only inject action/redirect if this is an HTTP request (indicated by RequestUri being present)
            if (string.IsNullOrEmpty(request.RequestUri))
            {
                return response;
            }

            var httpMethod = !string.IsNullOrEmpty(request.HttpMethod) ? request.HttpMethod : "POST";
            var actionUrl = request.RequestUri;

            if (actionUrl.Contains("?"))
            {
                actionUrl = actionUrl.Split('?')[0];
            }

            // List of verbs that support action and method attributes
            var verbs = new[]
            {
                "Gather",
                "GetText",
                "Pay",
                "Record",
                "Start",
                "Sms",
                "Refer",
                "Inbox",
                "Dial",
                "Connect"
            };

            bool actionInjected = false;

            foreach (var verb in verbs)
            {
                if (response.Contains($"<{verb}") && !response.Contains("action="))
                {
                    response = response.Replace($"<{verb}", $"<{verb} action=\"{actionUrl}\" method=\"{httpMethod}\"");
                    actionInjected = true;
                    // We assume only one main verb per response that needs action injection, 
                    // or at least if we inject one, we might not need a Redirect.
                    // However, TwiML can have multiple verbs. 
                    // The requirement "if no action in gather will need to ingect a action not a redirect"
                    // implies that if we inject an action, we don't need the fallback redirect.
                }
            }

            // Auto-inject Redirect if missing and no action was injected (and no existing action)
            if (!actionInjected && 
                !response.Contains("<Redirect") && 
                !response.Contains("action="))
            {
                var redirectTag = $"<Redirect method=\"{httpMethod}\">{actionUrl}</Redirect>";
                
                if (response.Contains("</Response>"))
                {
                    response = response.Replace("</Response>", $"{redirectTag}</Response>");
                }
                else
                {
                    response += redirectTag;
                }
            }

            return response;
        }
    }
}
