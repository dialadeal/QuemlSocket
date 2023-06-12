using System;
using System.Threading.Tasks;
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
            
            response.Append(record);
            var result = await _client.GetInputAsync(response.ToString());
            
            //play back first name
            response = new VoiceResponse();
            response.Append(new Play(new Uri(result["path"].ToString(), UriKind.Relative)));
            
            result = await _client.GetInputAsync(response.ToString());
            
            

            var getTextYiddish = new GetText()
            {
                Mode = GetText.ModeEnum.StarSeperated,
                Language = GetText.LanguageEnum.Yiddish,
            };
            getTextYiddish.Append(
                new Say("Welcome to Hazmuna, the best way to get your Hazmana. please enter your first name! "));

            getTextYiddish.Say("please choose a Title for the name you entered",
                forMenu: GetText.AvailableMenusEnum.Shortcuts);

            getTextYiddish.Say(
                "to continue typing press 1, to repeat back what you typed press 2, to delete last character press 3, to delete last word press 4, to exit press pound",
                forMenu: GetText.AvailableMenusEnum.Exit);

            response.Append(getTextYiddish);
            result = await _client.GetInputAsync(response.ToString());

            response = new VoiceResponse();
            response.Append(new Hangup());
            await _client.GetInputAsync(response.ToString());
        }
    }
}