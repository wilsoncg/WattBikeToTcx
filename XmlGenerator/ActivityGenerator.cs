using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlGenerator
{
    public class ActivityGenerator
    {
        private TrackPointGenerator _trackPointGenerator;

        public ActivityGenerator() : this(new TrackPointGenerator())
        {
        }

        public ActivityGenerator(TrackPointGenerator trackPointGenerator)
        {
            _trackPointGenerator = trackPointGenerator;
        }

        public ActivityLap_t Generate(DatLines activity)
        {
            var averageHeartRate = activity.AverageHeartRateBpm;
            var calories = activity.Calories;
            var totalTimeSeconds = Math.Round(activity.TotalTimeSeconds);
            var distance = activity.Distance;
            var maximumHeartRate = activity.MaximumHeartRate;
            var trackPoints = Trackpoints(activity);
            var lap = new ActivityLap_t
                {
                    StartTime = activity.ActivityStartTime,
                    TotalTimeSeconds = totalTimeSeconds,
                    DistanceMeters = distance,
                    AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = averageHeartRate },
                    MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = maximumHeartRate },
                    Calories = calories,
                    Intensity = Intensity_t.Active,
                    TriggerMethod = TriggerMethod_t.Manual,
                    Track = trackPoints,
                    Cadence = activity.AverageCadence,
                    CadenceSpecified = true
                };
            return lap;
        }

        private Trackpoint_t[] Trackpoints(DatLines activity)
        {
            var trackPoints = activity.Lines.Select(line => _trackPointGenerator.Generate(line, activity.ActivityStartTime)).ToArray();
            return trackPoints;
        }
    }
}
