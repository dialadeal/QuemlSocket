/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Voice.V1.DialingPermissions
{

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    ///
    /// Retrieve voice dialing country permissions identified by the given ISO country code
    /// </summary>
    public class FetchCountryOptions : IOptions<CountryResource>
    {
        /// <summary>
        /// The ISO country code
        /// </summary>
        public string PathIsoCode { get; }

        /// <summary>
        /// Construct a new FetchCountryOptions
        /// </summary>
        /// <param name="pathIsoCode"> The ISO country code </param>
        public FetchCountryOptions(string pathIsoCode)
        {
            PathIsoCode = pathIsoCode;
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
    /// Retrieve all voice dialing country permissions for this account
    /// </summary>
    public class ReadCountryOptions : ReadOptions<CountryResource>
    {
        /// <summary>
        /// Filter to retrieve the country permissions by specifying the ISO country code
        /// </summary>
        public string IsoCode { get; set; }
        /// <summary>
        /// Filter to retrieve the country permissions by specifying the continent
        /// </summary>
        public string Continent { get; set; }
        /// <summary>
        /// Country code filter
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Filter to retrieve the country permissions with dialing to low-risk numbers enabled
        /// </summary>
        public bool? LowRiskNumbersEnabled { get; set; }
        /// <summary>
        /// Filter to retrieve the country permissions with dialing to high-risk special service numbers enabled
        /// </summary>
        public bool? HighRiskSpecialNumbersEnabled { get; set; }
        /// <summary>
        /// Filter to retrieve the country permissions with dialing to high-risk toll fraud numbers enabled
        /// </summary>
        public bool? HighRiskTollfraudNumbersEnabled { get; set; }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (IsoCode != null)
            {
                p.Add(new KeyValuePair<string, string>("IsoCode", IsoCode.ToString()));
            }

            if (Continent != null)
            {
                p.Add(new KeyValuePair<string, string>("Continent", Continent));
            }

            if (CountryCode != null)
            {
                p.Add(new KeyValuePair<string, string>("CountryCode", CountryCode));
            }

            if (LowRiskNumbersEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("LowRiskNumbersEnabled", LowRiskNumbersEnabled.Value.ToString().ToLower()));
            }

            if (HighRiskSpecialNumbersEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("HighRiskSpecialNumbersEnabled", HighRiskSpecialNumbersEnabled.Value.ToString().ToLower()));
            }

            if (HighRiskTollfraudNumbersEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("HighRiskTollfraudNumbersEnabled", HighRiskTollfraudNumbersEnabled.Value.ToString().ToLower()));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

}