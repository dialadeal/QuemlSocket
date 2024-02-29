/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Conversations.V1
{

    /// <summary>
    /// Retrieve a list of all Conversations that this Participant belongs to by identity or by address. Only one parameter
    /// should be specified.
    /// </summary>
    public class ReadParticipantConversationOptions : ReadOptions<ParticipantConversationResource>
    {
        /// <summary>
        /// A unique string identifier for the conversation participant as Conversation User.
        /// </summary>
        public string Identity { get; set; }
        /// <summary>
        /// A unique string identifier for the conversation participant who's not a Conversation User.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }

            if (Address != null)
            {
                p.Add(new KeyValuePair<string, string>("Address", Address));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

}