using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Twilio.Converters;

namespace Twilio.TwiML.Voice
{
    public class GetTextYiddish : TwiML
    {
        /// <summary>
        /// Action URL
        /// </summary>
        public Uri Action { get; set; }
        /// <summary>
        /// Action URL For ReEnter
        /// </summary>
        public Uri ReEnterAction { get; set; }
        /// <summary>
        /// Time to wait to gather input
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// Time to wait to gather speech input and it should be either auto or a positive integer.
        /// </summary>
        public string SpeechTimeout { get; set; }
        /// <summary>
        /// Resume Enter Text To Text
        /// </summary>
        public string ResumeText { get; set; }
        /// <summary>
        /// Max allowed time for speech input
        /// </summary>
        public int? MaxSpeechTime { get; set; }
        /// <summary>
        /// Finish gather on key
        /// </summary>
        public string FinishOnKey { get; set; }
        /// <summary>
        /// Number of digits to collect
        /// </summary>
        public int? NumDigits { get; set; }

        /// <summary>
        /// Create a new Gather
        /// </summary>
        /// <param name="action"> Action URL </param>
        /// <param name="timeout"> Time to wait to gather input </param>
        /// <param name="speechTimeout"> Time to wait to gather speech input and it should be either auto or a positive
        ///                     integer. </param>
        /// <param name="maxSpeechTime"> Max allowed time for speech input </param>
        /// <param name="finishOnKey"> Finish gather on key </param>
        /// <param name="numDigits"> Number of digits to collect </param>
        public GetTextYiddish(Uri action = null,
                      int? timeout = null,
                      string speechTimeout = null,
                      int? maxSpeechTime = null,
                      string finishOnKey = null,
                      int? numDigits = null) : base("GetText")
        {
            this.Action = action;
            this.Timeout = timeout;
            this.SpeechTimeout = speechTimeout;
            this.MaxSpeechTime = maxSpeechTime;
            this.FinishOnKey = finishOnKey;
            this.NumDigits = numDigits;
        }

        /// <summary>
        /// Return the attributes of the TwiML tag
        /// </summary>
        protected override List<XAttribute> GetElementAttributes()
        {
            var attributes = new List<XAttribute>();

            if (this.Action != null)
            {
                attributes.Add(new XAttribute("action", Serializers.Url(this.Action)));
            }
            if (this.ReEnterAction != null)
            {
                attributes.Add(new XAttribute("reenterAction", Serializers.Url(this.ReEnterAction)));
            }
            if (this.ResumeText != null)
            {
                attributes.Add(new XAttribute("resumeText", this.ResumeText));
            }
            if (this.Timeout != null)
            {
                attributes.Add(new XAttribute("timeout", this.Timeout.ToString()));
            }
            if (this.SpeechTimeout != null)
            {
                attributes.Add(new XAttribute("speechTimeout", this.SpeechTimeout));
            }
            if (this.MaxSpeechTime != null)
            {
                attributes.Add(new XAttribute("maxSpeechTime", this.MaxSpeechTime.ToString()));
            }
            if (this.FinishOnKey != null)
            {
                attributes.Add(new XAttribute("finishOnKey", this.FinishOnKey));
            }
            if (this.NumDigits != null)
            {
                attributes.Add(new XAttribute("numDigits", this.NumDigits.ToString()));
            }
            return attributes;
        }
        /// <summary>
        /// Create a new <Say/> element and append it as a child of this element.
        /// </summary>
        /// <param name="message"> Message to say, the body of the TwiML Element. </param>
        /// <param name="voice"> Voice to use </param>
        /// <param name="loop"> Times to loop message </param>
        /// <param name="language"> Message langauge </param>
        public GetTextYiddish Say(string message = null,
                          Say.VoiceEnum voice = null,
                          int? loop = null,
                          Say.LanguageEnum language = null)
        {
            var newChild = new Say(message, voice, loop, language);
            this.Append(newChild);
            return this;
        }


        /// <summary>
        /// Create a new <Play/> element and append it as a child of this element.
        /// </summary>
        /// <param name="url"> Media URL, the body of the TwiML Element. </param>
        /// <param name="loop"> Times to loop media </param>
        /// <param name="digits"> Play DTMF tones for digits </param>
        public GetTextYiddish Play(Uri url = null, int? loop = null, string digits = null)
        {
            var newChild = new Play(url, loop, digits);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public new GetTextYiddish Append(TwiML childElem)
        {
            return (GetTextYiddish)base.Append(childElem);
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public new GetTextYiddish SetOption(string key, object value)
        {
            return (GetTextYiddish)base.SetOption(key, value);
        }

    }
}
