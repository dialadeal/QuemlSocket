using System;
using System.Collections.Generic;
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using Client = DamlSocket.Services.Client;
using Task = System.Threading.Tasks.Task;

namespace DamlSocketTest.Services
{
    public class FirstIvr
    {
        Client _client;
        SecondIvr _secondIvr;

        public FirstIvr(Client client, SecondIvr secondIvr)
        {
            _client = client;
            _secondIvr = secondIvr;
        }

        private static Uri CurentAction=new Uri("CollectUserInfo", UriKind.Relative);

        public async Task CollectUserInfo()
        {
            var context = await _client.GetContextAsync();
            var response = new VoiceResponse();
        
            response.Append(new Gather(input:new List<Gather.InputEnum>() { Gather.InputEnum.Dtmf }).Append(new Say("Welcome to the Twilio IVR demo. Please enter your account number, followed by the pound sign.")));
            // response.Append(new Redirect( ));

            var input =await _client.GetInputAsync(response.ToString());
            response = new VoiceResponse();
            response.Append(new Say("You entered " + input["text"] + ". Thank you."));
        
            response.Append(new Redirect(CurentAction));
        
            var input2 = await _client.GetInputAsync(response.ToString());

            await _secondIvr.Test2();
        }
    }
}

