/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Video.V1.Room.Participant
{

    /// <summary>
    /// Returns a single Track resource represented by `track_sid`.  Note: This is one resource with the Video API that
    /// requires a SID, be Track Name on the subscriber side is not guaranteed to be unique.
    /// </summary>
    public class FetchSubscribedTrackOptions : IOptions<SubscribedTrackResource>
    {
        /// <summary>
        /// The SID of the Room where the Track resource to fetch is subscribed
        /// </summary>
        public string PathRoomSid { get; }
        /// <summary>
        /// The SID of the participant that subscribes to the Track resource to fetch
        /// </summary>
        public string PathParticipantSid { get; }
        /// <summary>
        /// The SID that identifies the resource to fetch
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchSubscribedTrackOptions
        /// </summary>
        /// <param name="pathRoomSid"> The SID of the Room where the Track resource to fetch is subscribed </param>
        /// <param name="pathParticipantSid"> The SID of the participant that subscribes to the Track resource to fetch </param>
        /// <param name="pathSid"> The SID that identifies the resource to fetch </param>
        public FetchSubscribedTrackOptions(string pathRoomSid, string pathParticipantSid, string pathSid)
        {
            PathRoomSid = pathRoomSid;
            PathParticipantSid = pathParticipantSid;
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
    /// Returns a list of tracks that are subscribed for the participant.
    /// </summary>
    public class ReadSubscribedTrackOptions : ReadOptions<SubscribedTrackResource>
    {
        /// <summary>
        /// The SID of the Room resource with the Track resources to read
        /// </summary>
        public string PathRoomSid { get; }
        /// <summary>
        /// The SID of the participant that subscribes to the Track resources to read
        /// </summary>
        public string PathParticipantSid { get; }

        /// <summary>
        /// Construct a new ReadSubscribedTrackOptions
        /// </summary>
        /// <param name="pathRoomSid"> The SID of the Room resource with the Track resources to read </param>
        /// <param name="pathParticipantSid"> The SID of the participant that subscribes to the Track resources to read </param>
        public ReadSubscribedTrackOptions(string pathRoomSid, string pathParticipantSid)
        {
            PathRoomSid = pathRoomSid;
            PathParticipantSid = pathParticipantSid;
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