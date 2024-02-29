/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Autopilot.V1.Assistant
{

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    ///
    /// FetchQueryOptions
    /// </summary>
    public class FetchQueryOptions : IOptions<QueryResource>
    {
        /// <summary>
        /// The SID of the Assistant that is the parent of the resource to fetch
        /// </summary>
        public string PathAssistantSid { get; }
        /// <summary>
        /// The unique string that identifies the resource
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchQueryOptions
        /// </summary>
        /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the resource to fetch </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        public FetchQueryOptions(string pathAssistantSid, string pathSid)
        {
            PathAssistantSid = pathAssistantSid;
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
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    ///
    /// ReadQueryOptions
    /// </summary>
    public class ReadQueryOptions : ReadOptions<QueryResource>
    {
        /// <summary>
        /// The SID of the Assistant that is the parent of the resources to read
        /// </summary>
        public string PathAssistantSid { get; }
        /// <summary>
        /// The ISO language-country string that specifies the language used by the Query resources to read
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// The SID or unique name of the Model Build to be queried
        /// </summary>
        public string ModelBuild { get; set; }
        /// <summary>
        /// The status of the resources to read
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The SID of the [Dialogue](https://www.twilio.com/docs/autopilot/api/dialogue).
        /// </summary>
        public string DialogueSid { get; set; }

        /// <summary>
        /// Construct a new ReadQueryOptions
        /// </summary>
        /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the resources to read </param>
        public ReadQueryOptions(string pathAssistantSid)
        {
            PathAssistantSid = pathAssistantSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Language != null)
            {
                p.Add(new KeyValuePair<string, string>("Language", Language));
            }

            if (ModelBuild != null)
            {
                p.Add(new KeyValuePair<string, string>("ModelBuild", ModelBuild.ToString()));
            }

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status));
            }

            if (DialogueSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DialogueSid", DialogueSid.ToString()));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    ///
    /// CreateQueryOptions
    /// </summary>
    public class CreateQueryOptions : IOptions<QueryResource>
    {
        /// <summary>
        /// The SID of the Assistant that is the parent of the new resource
        /// </summary>
        public string PathAssistantSid { get; }
        /// <summary>
        /// The ISO language-country string that specifies the language used for the new query
        /// </summary>
        public string Language { get; }
        /// <summary>
        /// The end-user's natural language input
        /// </summary>
        public string Query { get; }
        /// <summary>
        /// The list of tasks to limit the new query to
        /// </summary>
        public string Tasks { get; set; }
        /// <summary>
        /// The SID or unique name of the Model Build to be queried
        /// </summary>
        public string ModelBuild { get; set; }

        /// <summary>
        /// Construct a new CreateQueryOptions
        /// </summary>
        /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the new resource </param>
        /// <param name="language"> The ISO language-country string that specifies the language used for the new query </param>
        /// <param name="query"> The end-user's natural language input </param>
        public CreateQueryOptions(string pathAssistantSid, string language, string query)
        {
            PathAssistantSid = pathAssistantSid;
            Language = language;
            Query = query;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Language != null)
            {
                p.Add(new KeyValuePair<string, string>("Language", Language));
            }

            if (Query != null)
            {
                p.Add(new KeyValuePair<string, string>("Query", Query));
            }

            if (Tasks != null)
            {
                p.Add(new KeyValuePair<string, string>("Tasks", Tasks));
            }

            if (ModelBuild != null)
            {
                p.Add(new KeyValuePair<string, string>("ModelBuild", ModelBuild.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    ///
    /// UpdateQueryOptions
    /// </summary>
    public class UpdateQueryOptions : IOptions<QueryResource>
    {
        /// <summary>
        /// The SID of the Assistant that is the parent of the resource to update
        /// </summary>
        public string PathAssistantSid { get; }
        /// <summary>
        /// The unique string that identifies the resource to update
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The SID of an optional reference to the Sample created from the query
        /// </summary>
        public string SampleSid { get; set; }
        /// <summary>
        /// The new status of the resource
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Construct a new UpdateQueryOptions
        /// </summary>
        /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the resource to update </param>
        /// <param name="pathSid"> The unique string that identifies the resource to update </param>
        public UpdateQueryOptions(string pathAssistantSid, string pathSid)
        {
            PathAssistantSid = pathAssistantSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (SampleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("SampleSid", SampleSid.ToString()));
            }

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status));
            }

            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    ///
    /// DeleteQueryOptions
    /// </summary>
    public class DeleteQueryOptions : IOptions<QueryResource>
    {
        /// <summary>
        /// The SID of the Assistant that is the parent of the resources to delete
        /// </summary>
        public string PathAssistantSid { get; }
        /// <summary>
        /// The unique string that identifies the resource
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteQueryOptions
        /// </summary>
        /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the resources to delete </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        public DeleteQueryOptions(string pathAssistantSid, string pathSid)
        {
            PathAssistantSid = pathAssistantSid;
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

}