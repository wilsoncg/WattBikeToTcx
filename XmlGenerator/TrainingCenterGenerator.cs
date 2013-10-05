using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace XmlGenerator
{
    public class TrainingCenterGenerator
    {
        private ActivityGenerator _activityGenerator;

        public TrainingCenterGenerator() : this(new ActivityGenerator())
        {
        }

        public TrainingCenterGenerator(ActivityGenerator activityGenerator)
        {
            _activityGenerator = activityGenerator;
        }

        public TrainingCenterDatabase_t Generate(List<DatLines> intervals, DateTime activityStartTime)
        {
            var tcd = new TrainingCenterDatabase_t();
            tcd.Author = new Application_t
                {
                    Name = "WattBikeToTcx",
                    Build = new Build_t
                        {
                            Version = new Version_t { VersionMajor = 1, VersionMinor = 0, BuildMajor = 0, BuildMinor = 0, BuildMajorSpecified = true, BuildMinorSpecified = true},
                            Type = BuildType_t.Release, 
                            TypeSpecified = true
                        },
                        LangID = "EN",
                        PartNumber = "000-A0000-00"
                };
            var activity = new[] { new Activity_t
                {
                    Sport = Sport_t.Biking,
                    Id = activityStartTime,
                    Lap = intervals.Select(_activityGenerator.Generate).ToArray(),
                    Creator = new Device_t
                        {
                            Name = "WattBike2013Pro",
                            UnitId = 00000000000,
                            ProductID = 000, 
                            Version = new Version_t { VersionMajor = 1, VersionMinor = 0, BuildMajor = 0, BuildMinor = 0, BuildMinorSpecified = true, BuildMajorSpecified = true}
                        }
                } };
            tcd.Activities = new ActivityList_t { Activity = activity };
            return tcd;
        }
    }
}
