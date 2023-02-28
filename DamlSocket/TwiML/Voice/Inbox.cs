using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Twilio.Converters;

namespace Twilio.TwiML.Voice
{
    public class Inbox:TwiML
    {
        /// <summary>
        /// Action URL
        /// </summary>
        public Uri Action { get; set; }
        /// <summary>
        /// Action URL method
        /// </summary>
        public Twilio.Http.HttpMethod Method { get; set; }
        /// <summary>
        /// Time to wait to gather input
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// Time to wait to gather speech input and it should be either auto or a positive integer.
        /// </summary>
        public string SpeechTimeout { get; set; }
        /// <summary>
        /// Max allowed time for speech input
        /// </summary>
        public int? MaxSpeechTime { get; set; }
        /// <summary>
        /// Profanity Filter on speech
        /// </summary>
        public bool? ProfanityFilter { get; set; }
        /// <summary>
        /// Finish gather on key
        /// </summary>
        public string FinishOnKey { get; set; }
        /// <summary>
        /// Number of digits to collect
        /// </summary>
        public int? NumDigits { get; set; }
        /// <summary>
        /// Partial result callback URL
        /// </summary>
        public Uri PartialResultCallback { get; set; }
        /// <summary>
        /// Partial result callback URL method
        /// </summary>
        public Twilio.Http.HttpMethod PartialResultCallbackMethod { get; set; }
        /// <summary>
        /// Language to use
        /// </summary>
        public Gather.LanguageEnum Language { get; set; }
        /// <summary>
        /// Speech recognition hints
        /// </summary>
        public string Hints { get; set; }
        /// <summary>
        /// Stop playing media upon speech
        /// </summary>
        public bool? BargeIn { get; set; }
        /// <summary>
        /// Allow debug for gather
        /// </summary>
        public bool? Debug { get; set; }
        /// <summary>
        /// Force webhook to the action URL event if there is no input
        /// </summary>
        public bool? ActionOnEmptyResult { get; set; }
        /// <summary>
        /// Specify the model that is best suited for your use case
        /// </summary>
        public Gather.SpeechModelEnum SpeechModel { get; set; }
        /// <summary>
        /// Use enhanced speech model
        /// </summary>
        public bool? Enhanced { get; set; }

        /// <summary>
        /// Create a new Gather
        /// </summary>
        /// <param name="input"> Input type Twilio should accept </param>
        /// <param name="action"> Action URL </param>
        /// <param name="method"> Action URL method </param>
        /// <param name="timeout"> Time to wait to gather input </param>
        /// <param name="speechTimeout"> Time to wait to gather speech input and it should be either auto or a positive
        ///                     integer. </param>
        /// <param name="maxSpeechTime"> Max allowed time for speech input </param>
        /// <param name="profanityFilter"> Profanity Filter on speech </param>
        /// <param name="finishOnKey"> Finish gather on key </param>
        /// <param name="numDigits"> Number of digits to collect </param>
        /// <param name="partialResultCallback"> Partial result callback URL </param>
        /// <param name="partialResultCallbackMethod"> Partial result callback URL method </param>
        /// <param name="language"> Language to use </param>
        /// <param name="hints"> Speech recognition hints </param>
        /// <param name="bargeIn"> Stop playing media upon speech </param>
        /// <param name="debug"> Allow debug for gather </param>
        /// <param name="actionOnEmptyResult"> Force webhook to the action URL event if there is no input </param>
        /// <param name="speechModel"> Specify the model that is best suited for your use case </param>
        /// <param name="enhanced"> Use enhanced speech model </param>
        public Inbox( Uri action = null,
                      Twilio.Http.HttpMethod method = null,
                      int? timeout = null,
                      string speechTimeout = null,
                      int? maxSpeechTime = null,
                      bool? profanityFilter = null,
                      string finishOnKey = null,
                      int? numDigits = null,
                      Uri partialResultCallback = null,
                      Twilio.Http.HttpMethod partialResultCallbackMethod = null,
                      Gather.LanguageEnum language = null,
                      string hints = null,
                      bool? bargeIn = null,
                      bool? debug = null,
                      bool? actionOnEmptyResult = null,
                      Gather.SpeechModelEnum speechModel = null,
                      bool? enhanced = null) : base("Inbox")
        {
            this.Action = action;
            this.Method = method;
            this.Timeout = timeout;
            this.SpeechTimeout = speechTimeout;
            this.MaxSpeechTime = maxSpeechTime;
            this.ProfanityFilter = profanityFilter;
            this.FinishOnKey = finishOnKey;
            this.NumDigits = numDigits;
            this.PartialResultCallback = partialResultCallback;
            this.PartialResultCallbackMethod = partialResultCallbackMethod;
            this.Language = language;
            this.Hints = hints;
            this.BargeIn = bargeIn;
            this.Debug = debug;
            this.ActionOnEmptyResult = actionOnEmptyResult;
            this.SpeechModel = speechModel;
            this.Enhanced = enhanced;
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
            if (this.Method != null)
            {
                attributes.Add(new XAttribute("method", this.Method.ToString()));
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
            if (this.ProfanityFilter != null)
            {
                attributes.Add(new XAttribute("profanityFilter", this.ProfanityFilter.Value.ToString().ToLower()));
            }
            if (this.FinishOnKey != null)
            {
                attributes.Add(new XAttribute("finishOnKey", this.FinishOnKey));
            }
            if (this.NumDigits != null)
            {
                attributes.Add(new XAttribute("numDigits", this.NumDigits.ToString()));
            }
            if (this.PartialResultCallback != null)
            {
                attributes.Add(new XAttribute("partialResultCallback", Serializers.Url(this.PartialResultCallback)));
            }
            if (this.PartialResultCallbackMethod != null)
            {
                attributes.Add(new XAttribute("partialResultCallbackMethod", this.PartialResultCallbackMethod.ToString()));
            }
            if (this.Language != null)
            {
                attributes.Add(new XAttribute("language", this.Language.ToString()));
            }
            if (this.Hints != null)
            {
                attributes.Add(new XAttribute("hints", this.Hints));
            }
            if (this.BargeIn != null)
            {
                attributes.Add(new XAttribute("bargeIn", this.BargeIn.Value.ToString().ToLower()));
            }
            if (this.Debug != null)
            {
                attributes.Add(new XAttribute("debug", this.Debug.Value.ToString().ToLower()));
            }
            if (this.ActionOnEmptyResult != null)
            {
                attributes.Add(new XAttribute("actionOnEmptyResult", this.ActionOnEmptyResult.Value.ToString().ToLower()));
            }
            if (this.SpeechModel != null)
            {
                attributes.Add(new XAttribute("speechModel", this.SpeechModel.ToString()));
            }
            if (this.Enhanced != null)
            {
                attributes.Add(new XAttribute("enhanced", this.Enhanced.Value.ToString().ToLower()));
            }
            return attributes;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public new Inbox Append(TwiML childElem)
        {
            return (Inbox)base.Append(childElem);
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public new Inbox SetOption(string key, object value)
        {
            return (Inbox)base.SetOption(key, value);
        }

    }
}
