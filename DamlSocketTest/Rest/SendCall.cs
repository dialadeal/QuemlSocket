using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WorkerServiceTest.Rest
{
    public class SendCall
    {
        public void Send()
        {
            string accountSid = "kellner";
            string authToken = "ArAilHVOoL3upXsdfh78Cohq";

            TwilioClient.Init(accountSid, authToken);

            var call = CallResource.Create(
                method: Twilio.Http.HttpMethod.Get,
                to: new Twilio.Types.PhoneNumber("+18453764032"),
                from: new Twilio.Types.PhoneNumber("+18454441114"),
                callerId: "+18454441114",
                dialplanName: "+18454441114"
            );
        }
    }
}