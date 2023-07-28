using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Twilio.Converters;
using Twilio.Types;

namespace Twilio.TwiML.Voice
{
    public class GetText : TwiML
    {
        public sealed class LanguageEnum : StringEnum
        {
            private LanguageEnum(string value) : base(value)
            {
            }

            public LanguageEnum()
            {
            }

            public static implicit operator LanguageEnum(string value)
            {
                return new LanguageEnum(value);
            }

            public static readonly LanguageEnum Yiddish = new LanguageEnum("yiddish");
            public static readonly LanguageEnum EnUs = new LanguageEnum("en-US");
        }

        public sealed class ModeEnum : StringEnum
        {
            private ModeEnum(string value) : base(value)
            {
            }

            public ModeEnum()
            {
            }

            public static implicit operator ModeEnum(string value)
            {
                return new ModeEnum(value);
            }

            public static readonly ModeEnum TimeSeperated = new ModeEnum("time-seperated");
            public static readonly ModeEnum StarSeperated = new ModeEnum("star-seperated");
        }

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
        /// Mode of the GetText
        ///
        public GetText.ModeEnum Mode { get; set; }

        public GetText.LanguageEnum Language { get; set; }

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
        public GetText(Uri action = null,
            int? timeout = null,
            string speechTimeout = null,
            int? maxSpeechTime = null,
            string finishOnKey = null,
            int? numDigits = null,
            LanguageEnum language = null,
            ModeEnum mode = null) : base("GetText")
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

            if (this.Mode != null)
            {
                attributes.Add(new XAttribute("mode", this.Mode.ToString()));
            }

            if (this.Language != null)
            {
                attributes.Add(new XAttribute("language", this.Language.ToString()));
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
        public GetText Say(string message = null,
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
        public GetText Play(Uri url = null, int? loop = null, string digits = null)
        {
            var newChild = new Play(url, loop, digits);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// you can add or override a mapping for a key pressed by the user to a value you specify.
        /// you can add a play or say element to the mapping to play a message on key press.
        /// to add mapping that should exit the get text, append a redirect element to the mapping.
        /// </summary>
        public GetText AppendMapping(string keyPressed, string value)
        {
            var newChild = new GetTextMapping(keyPressed, value);
            this.Append(newChild);
            return this;
        }

        public GetText AppendMapping(string keyPressed, GetTextMapping.FunctionEnum function)
        {
            var newChild = new GetTextMapping(keyPressed, value: null, function);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public new GetText Append(TwiML childElem)
        {
            return (GetText)base.Append(childElem);
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public new GetText SetOption(string key, object value)
        {
            return (GetText)base.SetOption(key, value);
        }
    }
}