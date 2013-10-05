using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XmlGenerator
{
    public class TrackPointGenerator
    {
        public Trackpoint_t Generate(DatLine datLine, DateTime activityStartTime)
        {
            var speed = Decimal.Round(datLine.Speed * 0.277777778m, 2);
            var tpx = new TPX { Speed = speed, Watts = datLine.Power };
            var addedHours = activityStartTime.AddHours(datLine.ElapsedTimeTotal.Hours);
            var addedHoursAndMinutes = addedHours.AddMinutes(datLine.ElapsedTimeTotal.Minutes);
            var addedHoursMinutesSeconds = addedHoursAndMinutes.AddSeconds(datLine.ElapsedTimeTotal.Seconds);
            var time = addedHoursMinutesSeconds;
            var trackpoint = new Trackpoint_t
                {
                    AltitudeMeters = 0,
                    Time = time,
                    HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = (byte)datLine.HeartRate },
                    Cadence = (byte)datLine.Cadence,
                    CadenceSpecified = true,
                    DistanceMeters = (double)datLine.DistanceTotal,
                    DistanceMetersSpecified = true,
                    Extensions = new Extensions_t { TPX =  tpx }
                };
            return trackpoint;
        }
    }
}
