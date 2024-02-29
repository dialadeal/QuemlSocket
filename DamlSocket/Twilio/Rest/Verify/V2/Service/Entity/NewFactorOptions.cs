/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Verify.V2.Service.Entity
{

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Create a new Factor for the Entity
    /// </summary>
    public class CreateNewFactorOptions : IOptions<NewFactorResource>
    {
        /// <summary>
        /// Service Sid.
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// Unique external identifier of the Entity
        /// </summary>
        public string PathIdentity { get; }
        /// <summary>
        /// The friendly name of this Factor
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// The Type of this Factor
        /// </summary>
        public NewFactorResource.FactorTypesEnum FactorType { get; }
        /// <summary>
        /// The algorithm used when `factor_type` is `push`
        /// </summary>
        public string BindingAlg { get; set; }
        /// <summary>
        /// The public key encoded in Base64
        /// </summary>
        public string BindingPublicKey { get; set; }
        /// <summary>
        /// The ID that uniquely identifies your app in the Google or Apple store
        /// </summary>
        public string ConfigAppId { get; set; }
        /// <summary>
        /// The transport technology used to generate the Notification Token
        /// </summary>
        public NewFactorResource.NotificationPlatformsEnum ConfigNotificationPlatform { get; set; }
        /// <summary>
        /// For APN, the device token. For FCM, the registration token
        /// </summary>
        public string ConfigNotificationToken { get; set; }
        /// <summary>
        /// The Verify Push SDK version used to configure the factor
        /// </summary>
        public string ConfigSdkVersion { get; set; }
        /// <summary>
        /// The shared secret in Base32
        /// </summary>
        public string BindingSecret { get; set; }
        /// <summary>
        /// How often, in seconds, are TOTP codes generated
        /// </summary>
        public int? ConfigTimeStep { get; set; }
        /// <summary>
        /// The number of past and future time-steps valid at a given time
        /// </summary>
        public int? ConfigSkew { get; set; }
        /// <summary>
        /// Number of digits for generated TOTP codes
        /// </summary>
        public int? ConfigCodeLength { get; set; }
        /// <summary>
        /// The algorithm used to derive the TOTP codes
        /// </summary>
        public NewFactorResource.TotpAlgorithmsEnum ConfigAlg { get; set; }
        /// <summary>
        /// Metadata of the factor.
        /// </summary>
        public object Metadata { get; set; }

        /// <summary>
        /// Construct a new CreateNewFactorOptions
        /// </summary>
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathIdentity"> Unique external identifier of the Entity </param>
        /// <param name="friendlyName"> The friendly name of this Factor </param>
        /// <param name="factorType"> The Type of this Factor </param>
        public CreateNewFactorOptions(string pathServiceSid,
                                      string pathIdentity,
                                      string friendlyName,
                                      NewFactorResource.FactorTypesEnum factorType)
        {
            PathServiceSid = pathServiceSid;
            PathIdentity = pathIdentity;
            FriendlyName = friendlyName;
            FactorType = factorType;
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

            if (FactorType != null)
            {
                p.Add(new KeyValuePair<string, string>("FactorType", FactorType.ToString()));
            }

            if (BindingAlg != null)
            {
                p.Add(new KeyValuePair<string, string>("Binding.Alg", BindingAlg));
            }

            if (BindingPublicKey != null)
            {
                p.Add(new KeyValuePair<string, string>("Binding.PublicKey", BindingPublicKey.ToString()));
            }

            if (ConfigAppId != null)
            {
                p.Add(new KeyValuePair<string, string>("Config.AppId", ConfigAppId));
            }

            if (ConfigNotificationPlatform != null)
            {
                p.Add(new KeyValuePair<string, string>("Config.NotificationPlatform", ConfigNotificationPlatform.ToString()));
            }

            if (ConfigNotificationToken != null)
            {
                p.Add(new KeyValuePair<string, string>("Config.NotificationToken", ConfigNotificationToken));
            }

            if (ConfigSdkVersion != null)
            {
                p.Add(new KeyValuePair<string, string>("Config.SdkVersion", ConfigSdkVersion));
            }

            if (BindingSecret != null)
            {
                p.Add(new KeyValuePair<string, string>("Binding.Secret", BindingSecret));
            }

            if (ConfigTimeStep != null)
            {
                p.Add(new KeyValuePair<string, string>("Config.TimeStep", ConfigTimeStep.ToString()));
            }

            if (ConfigSkew != null)
            {
                p.Add(new KeyValuePair<string, string>("Config.Skew", ConfigSkew.ToString()));
            }

            if (ConfigCodeLength != null)
            {
                p.Add(new KeyValuePair<string, string>("Config.CodeLength", ConfigCodeLength.ToString()));
            }

            if (ConfigAlg != null)
            {
                p.Add(new KeyValuePair<string, string>("Config.Alg", ConfigAlg.ToString()));
            }

            if (Metadata != null)
            {
                p.Add(new KeyValuePair<string, string>("Metadata", Serializers.JsonObject(Metadata)));
            }

            return p;
        }
    }

}