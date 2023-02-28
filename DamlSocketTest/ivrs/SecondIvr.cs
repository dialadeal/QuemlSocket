using System;
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using Task = System.Threading.Tasks.Task;

namespace WorkerServiceSuperSocket.Services
{
    public class SecondIvr
    {
        Client _client;

        public SecondIvr(Client client)
        {
            _client = client;
        }
        public static Uri CurrentUri =new Uri("Test2", UriKind.Relative);
        public async Task Test2()
        {
            var rsponse = new VoiceResponse();
            var gather = new Gather(action:CurrentUri);
            gather.Append(new Say("Press 1 to speak to a sales representative. Press 2 to hear our most popular products."));
        
            rsponse.Append(gather);
            var input = await _client.GetInputAsync(rsponse.ToString());
        
            rsponse= new VoiceResponse();
        
            if (input["digits"].ToString() == "1")
            {
                rsponse.Append(new Say("You will now be connected to a sales representative."));
                rsponse.Append(new Dial("+18454441114"));
            }
            else if (input["digits"].ToString() == "2")
            {
                rsponse.Append(new Say("Our most popular products are our Twilio t-shirts and Twilio mugs."));
            }
            else
            {
                rsponse.Append(new Say("Sorry, I don't understand that choice."));
            }
       
            var response = await _client.GetInputAsync(rsponse.ToString());
        }
    }
}

