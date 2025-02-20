/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Twilio.Converters;
using Twilio.Types;

namespace Twilio.TwiML.Voice
{

    /// <summary>
    /// Redirect TwiML Verb
    /// </summary>
    public class Redirect : TwiML
    {
        
        public sealed class ClientTypeEnum : StringEnum
        {
            private ClientTypeEnum(string value) : base(value) {}
            public ClientTypeEnum() {}
            public static implicit operator ClientTypeEnum(string value)
            {
                return new ClientTypeEnum(value);
            }

            public static readonly ClientTypeEnum Rest = new ClientTypeEnum("rest");
            public static readonly ClientTypeEnum Socket = new ClientTypeEnum("socket");
        }
        
        /// <summary>
        /// Redirect URL
        /// </summary>
        public Uri Url { get; set; }
        /// <summary>
        /// Redirect URL method
        /// </summary>
        public Twilio.Http.HttpMethod Method { get; set; }
        
        /// <summary>
        /// this is used for socket method redirect
        /// enter the method name you want the socket to call
        /// </summary>
        public string SocketMethod { get; set; }
        
        /// <summary>
        /// set the client type to switch between socket and http
        /// </summary>
        public ClientTypeEnum ClientType { get; set; } 

        /// <summary>
        /// Create a new Redirect
        /// </summary>
        /// <param name="url"> Redirect URL, the body of the TwiML Element. </param>
        /// <param name="method"> Redirect URL method </param>
        public Redirect(Uri url = null, Twilio.Http.HttpMethod method = null) : base("Redirect")
        {
            this.Url = url;
            this.Method = method;
        }

        /// <summary>
        /// Return the body of the TwiML tag
        /// </summary>
        protected override string GetElementBody()
        {
            return this.Url != null ? Serializers.Url(this.Url) : string.Empty;
        }

        /// <summary>
        /// Return the attributes of the TwiML tag
        /// </summary>
        protected override List<XAttribute> GetElementAttributes()
        {
            var attributes = new List<XAttribute>();
            if (this.Method != null)
            {
                attributes.Add(new XAttribute("method", this.Method.ToString()));
            }
            
            if (this.SocketMethod != null)
            {
                attributes.Add(new XAttribute("socket_method", this.SocketMethod.ToString()));
            }
            
            if (this.ClientType != null)
            {
                attributes.Add(new XAttribute("client_type", this.ClientType.ToString()));
            }
            
            return attributes;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public new Redirect Append(TwiML childElem)
        {
            return (Redirect) base.Append(childElem);
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public new Redirect SetOption(string key, object value)
        {
            return (Redirect) base.SetOption(key, value);
        }
    }

}