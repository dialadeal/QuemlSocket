/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Verify.V2.Service
{

    /// <summary>
    /// challenge a specific Verification Check.
    /// </summary>
    public class CreateVerificationCheckOptions : IOptions<VerificationCheckResource>
    {
        /// <summary>
        /// The SID of the verification Service to create the resource under
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The verification string
        /// </summary>
        public string Code { get; }
        /// <summary>
        /// The phone number or email to verify
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// A SID that uniquely identifies the Verification Check
        /// </summary>
        public string VerificationSid { get; set; }
        /// <summary>
        /// The amount of the associated PSD2 compliant transaction.
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// The payee of the associated PSD2 compliant transaction
        /// </summary>
        public string Payee { get; set; }

        /// <summary>
        /// Construct a new CreateVerificationCheckOptions
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the verification Service to create the resource under </param>
        /// <param name="code"> The verification string </param>
        public CreateVerificationCheckOptions(string pathServiceSid, string code)
        {
            PathServiceSid = pathServiceSid;
            Code = code;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Code != null)
            {
                p.Add(new KeyValuePair<string, string>("Code", Code));
            }

            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To));
            }

            if (VerificationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VerificationSid", VerificationSid.ToString()));
            }

            if (Amount != null)
            {
                p.Add(new KeyValuePair<string, string>("Amount", Amount));
            }

            if (Payee != null)
            {
                p.Add(new KeyValuePair<string, string>("Payee", Payee));
            }

            return p;
        }
    }

}