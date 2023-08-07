using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using Client = DamlSocket.Services.Client;

namespace HazmunaService.Ivrs
{
    public class WelcomeIvr
    {
        private readonly Client _client;
        private static Uri CurrentAction = new Uri("Welcome", UriKind.Relative);
        public static readonly string AudioUrl = "http://sip.dialadeal.net:5004";

        public static string baseFilePath = "file_string:///var/lib/freeswitch/recordings/sip.dialadeal.net/";
        public static string recordFilePath(int id) => baseFilePath + $"recording{id}.wav";

        public WelcomeIvr(Client client)
        {
            _client = client;
        }

        public async Task Welcome()
        {
            var context = await _client.GetContextAsync();
            var response = new VoiceResponse();
            
            // recrod first name
            var record = new Record();
            record.Append(new Say("Welcome to Hazmuna, the best way to get your Hazmana. please enter your first name! "));
            
            // response.Append(record);
            // var result = await _client.GetInputAsync(response.ToString());
            //
            // //play back first name
            // response = new VoiceResponse();
            // response.Append(new Play(new Uri(result["path"].ToString(), UriKind.Relative)));
            //
            // result = await _client.GetInputAsync(response.ToString());
            
            JToken result;

            var getTextYiddish = new GetText()
            {
                Mode = GetText.ModeEnum.StarSeperated,
                Language = GetText.LanguageEnum.Yiddish,
            };
            
            getTextYiddish.AppendMapping("11","@");
            getTextYiddish.AppendMapping("0",GetTextMapping.FunctionEnum.PlayAll);
            getTextYiddish.AppendMapping("111",GetTextMapping.FunctionEnum.Exit);
            
            getTextYiddish.Append(
                new Say("Welcome to Hazmuna, the best way to get your Hazmana. please enter your first name! "));


            response.Append(getTextYiddish);
            result = await _client.GetInputAsync(response.ToString());

            response = new VoiceResponse();
            response.Append(new Hangup());
             _client.GetInputAsync(response.ToString());
        }
    }
}