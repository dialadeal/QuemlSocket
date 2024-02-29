/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Preview.BulkExports.Export
{

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    ///
    /// Fetch a specific Day.
    /// </summary>
    public class FetchDayOptions : IOptions<DayResource>
    {
        /// <summary>
        /// The type of communication – Messages, Calls, Conferences, and Participants
        /// </summary>
        public string PathResourceType { get; }
        /// <summary>
        /// The date of the data in the file
        /// </summary>
        public string PathDay { get; }

        /// <summary>
        /// Construct a new FetchDayOptions
        /// </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        /// <param name="pathDay"> The date of the data in the file </param>
        public FetchDayOptions(string pathResourceType, string pathDay)
        {
            PathResourceType = pathResourceType;
            PathDay = pathDay;
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
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    ///
    /// Retrieve a list of all Days for a resource.
    /// </summary>
    public class ReadDayOptions : ReadOptions<DayResource>
    {
        /// <summary>
        /// The type of communication – Messages, Calls, Conferences, and Participants
        /// </summary>
        public string PathResourceType { get; }

        /// <summary>
        /// Construct a new ReadDayOptions
        /// </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        public ReadDayOptions(string pathResourceType)
        {
            PathResourceType = pathResourceType;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

}