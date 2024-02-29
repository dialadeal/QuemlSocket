/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.FrontlineApi.V1
{

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Fetch a frontline user
    /// </summary>
    public class FetchUserOptions : IOptions<UserResource>
    {
        /// <summary>
        /// The SID of the User resource to fetch
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchUserOptions
        /// </summary>
        /// <param name="pathSid"> The SID of the User resource to fetch </param>
        public FetchUserOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Update an existing frontline user
    /// </summary>
    public class UpdateUserOptions : IOptions<UserResource>
    {
        /// <summary>
        /// The SID of the User resource to update
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The string that you assigned to describe the User
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The avatar URL which will be shown in Frontline application
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// Current state of this user
        /// </summary>
        public UserResource.StateTypeEnum State { get; set; }
        /// <summary>
        /// Whether the User is available for new conversations
        /// </summary>
        public bool? IsAvailable { get; set; }

        /// <summary>
        /// Construct a new UpdateUserOptions
        /// </summary>
        /// <param name="pathSid"> The SID of the User resource to update </param>
        public UpdateUserOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (Avatar != null)
            {
                p.Add(new KeyValuePair<string, string>("Avatar", Avatar));
            }

            if (State != null)
            {
                p.Add(new KeyValuePair<string, string>("State", State.ToString()));
            }

            if (IsAvailable != null)
            {
                p.Add(new KeyValuePair<string, string>("IsAvailable", IsAvailable.Value.ToString().ToLower()));
            }

            return p;
        }
    }

}