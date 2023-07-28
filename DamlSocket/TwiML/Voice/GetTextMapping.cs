using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Twilio.Converters;
using Twilio.Types;

namespace Twilio.TwiML.Voice
{
    public class GetTextMapping : TwiML
    {
        public sealed class FunctionEnum : StringEnum
        {
            private FunctionEnum(string value) : base(value)
            {
            }

            public FunctionEnum()
            {
            }

            public static implicit operator FunctionEnum(string value)
            {
                return new FunctionEnum(value);
            }

            public static readonly FunctionEnum Exit = new FunctionEnum("exit");
            public static readonly FunctionEnum Space = new FunctionEnum("Space");
            public static readonly FunctionEnum Backspace = new FunctionEnum("trim");
            public static readonly FunctionEnum PlayAll = new FunctionEnum("playAll");
        }

        public GetTextMapping(string keyPressed, string value, FunctionEnum function = null) : base("GetTextMapping")
        {
            this.KeyPressed = keyPressed;
            this.Value = value;
            this.Function = function;
        }

        /// <summary>
        /// when the user presses a key, the key pressed will be replaced with the value provided
        /// </summary>
        public string KeyPressed { get; set; }

        /// <summary>
        /// provide a value to be used when the user pressed provided key
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Perform a function on key press
        /// </summary>
        public FunctionEnum Function { get; set; }

        /// <summary>
        /// Create a new <Say/> element and append it as a child of this element.
        /// </summary>
        /// <param name="message"> Message to say, the body of the TwiML Element. </param>
        /// <param name="voice"> Voice to use </param>
        /// <param name="loop"> Times to loop message </param>
        /// <param name="language"> Message langauge </param>
        public GetTextMapping Say(string message = null,
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
        public GetTextMapping Play(Uri url = null, int? loop = null, string digits = null)
        {
            var newChild = new Play(url, loop, digits);

            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public new GetTextMapping Append(TwiML childElem)
        {
            return (GetTextMapping)base.Append(childElem);
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public new GetTextMapping SetOption(string key, object value)
        {
            return (GetTextMapping)base.SetOption(key, value);
        }


        /// <summary>
        /// Return the attributes of the TwiML tag
        /// </summary>
        protected override List<XAttribute> GetElementAttributes()
        {
            var attributes = new List<XAttribute>();

            if (this.KeyPressed != null)
            {
                attributes.Add(new XAttribute("keyPressed", this.KeyPressed));
            }

            if (this.Value != null)
            {
                attributes.Add(new XAttribute("value", this.Value));
            }
            
            if (this.Function != null)
            {
                attributes.Add(new XAttribute("function", this.Function.ToString()));
            }

            return attributes;
        }
    }
}