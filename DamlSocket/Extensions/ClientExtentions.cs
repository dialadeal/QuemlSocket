using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using Client = DamlSocket.Services.Client;

namespace DamlSocket.Extensions
{
    public static class ClientExtensions
    {
        public static async Task<string> CollectTextSayOrPlay(this Client client, string say, string? sayUrl = null)
        {
            var response = new VoiceResponse();
            var getText = new GetText();


            if (sayUrl == null) getText.Say(say);
            else getText.Play(new Uri(sayUrl));
            response.Append(getText);

            var result = (await client.GetInputAsync(response.ToString()))["text"].ToString();

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            return textInfo.ToTitleCase(result);
        }

        public static async Task<string> CollectTextSayOrPlayAndConfirm(this Client client, string say,
            string? sayUrl = null)
        {
            var result = await CollectTextSayOrPlay(client, say, sayUrl);

            var confirm = await client.ConfirmResult(result);

            if (confirm) return result;
            else return await client.CollectTextSayOrPlayAndConfirm(say, sayUrl);
        }

        public static async Task<bool> ConfirmResult(this Client client, string resultText,
            List<string>? confirmRecordingsUrls = null, string? preSayText = null)
        {
            //ask if the result is correct
            var response = new VoiceResponse();
            var gather = new Gather(
                numDigits: 1
            );


            preSayText = preSayText != null ? preSayText : "You entered";


            gather.Say(preSayText);


            if (confirmRecordingsUrls == null || !confirmRecordingsUrls.Any())
            {
                gather.Say(resultText);
            }
            else
            {
                foreach (var confirmRecordingsUrl in confirmRecordingsUrls)
                {
                    gather.Play(new Uri(confirmRecordingsUrl));
                }
            }


            gather.Say("If this is correct, press 1. If not, press 2. To repeat, press 0.");


            response.Append(gather);

            var confirm = (await client.GetInputAsync(response.ToString()))["digits"].ToString();

            switch (confirm)
            {
                case "1":
                    return true;
                    break;
                case "2":
                    return false;
                    break;
                case "0":
                    return await client.ConfirmResult(resultText, confirmRecordingsUrls, preSayText);
                    break;
                default:
                    return await client.ConfirmResult(resultText, confirmRecordingsUrls, preSayText);
                    break;
            }
        }


        public static async Task<string> CollectDigitsSayOrPlay(this Client client, string say, int? numDigits = null,
            string? sayUrl = null)
        {
            mainMenu:

            var response = new VoiceResponse();

            var gather = new Gather(
                numDigits: numDigits
            );

            if (sayUrl == null)
            {
                gather.Say(say);
            }
            else
            {
                gather.Play(new Uri(sayUrl));
            }

            response.Append(gather);

            var result = (await client.GetInputAsync(response.ToString()))["digits"].ToString();

            if (numDigits == null || result.Length == numDigits)
            {
                return result;
            }
            else
            {
                goto mainMenu;
            }
        }

        public static async Task<string> CollectDigitsSayOrPlayAndConfirm(this Client client, string say,
            int? numDigits = null, string? sayUrl = null)
        {
            var result = await client.CollectDigitsSayOrPlay(say, numDigits, sayUrl);

            var confirm = await client.ConfirmResult(result);

            if (confirm) return result;
            else return await client.CollectDigitsSayOrPlayAndConfirm(say, numDigits, sayUrl);
        }

        public static async Task<string> SpeechToText(this Client client, string say)
        {
            var response = new VoiceResponse();
            var gather = new Gather(input: new List<Gather.InputEnum>() { Gather.InputEnum.Speech }, speechTimeout: "5",
                confirmInput: true, speechModel: Gather.SpeechModelEnum.CommandAndSearch);
            gather.Say(say);
            response.Append(gather);
        
            var result = (await client.GetInputAsync(response.ToString()))["text"].ToString();
        
            return result;
        }

        public static async Task<string> CollectDigits(this Client client, string say, int? numDigits = null,
            bool confirmResult = false, bool allowEmptyResult = false)
        {
            var response = new VoiceResponse();

            var gather = new Gather(
                numDigits: numDigits
            );

            gather.Say(say);
            response.Append(gather);

            var result = (await client.GetInputAsync(response.ToString()))["digits"].ToString();


            if (string.IsNullOrWhiteSpace(result) && !allowEmptyResult)
            {
                return await client.CollectDigits(say, numDigits);
            }

            if (confirmResult)
            {
                var confirm = await client.ConfirmResult(result);

                if (confirm) return result;
                else return await client.CollectDigits(say, numDigits, confirmResult, allowEmptyResult);
            }

            return result;
        }

        public static async Task SayMessage(this Client client, string msg)
        {
            VoiceResponse voiceResponse = new VoiceResponse();

            var say = new Say(msg);
            voiceResponse.Append(say);
            await client.GetInputAsync(voiceResponse.ToString());
        }

        // Dial a number
        public static async Task Dial(this Client client, string number, string callerId = null)
        {
            VoiceResponse voiceResponse = new VoiceResponse();
            var dial = new Dial(number, callerId: callerId);
            voiceResponse.Append(dial);
            await client.GetInputAsync(voiceResponse.ToString());
        }
        
        public static void  DirectToHttp(this Client client,string controllerAction)
        {
            VoiceResponse response = new VoiceResponse();
            var redirect = new Redirect(new Uri(controllerAction, UriKind.Relative))
            {
                ClientType = Twilio.TwiML.Voice.Redirect.ClientTypeEnum.Rest
            };

            response.Append(redirect);

            client.ExecuteRedirect(response.ToString());
        }

        public static VoiceResponse DirectToSocket(string url, string socketMethodName , int port )
        {
            var response = new VoiceResponse();
            var redirect = new Redirect(new Uri(url+ $":{port}"))
            {
                ClientType = Twilio.TwiML.Voice.Redirect.ClientTypeEnum.Socket,
                SocketMethod = socketMethodName,
            };

            response.Append(redirect);
            return response;

        }

        // Hangup 
    }
}