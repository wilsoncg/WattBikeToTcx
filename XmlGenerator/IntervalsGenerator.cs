using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlGenerator
{
    public class IntervalsGenerator
    {
        private DatLinesGenerator _datLinesGenerator;

        public IntervalsGenerator() : this(new DatLinesGenerator())
        {
        }

        public IntervalsGenerator(DatLinesGenerator datLinesGenerator)
        {
            _datLinesGenerator = datLinesGenerator;
        }

        public List<DatLines> CreateIntervalsWithCorrectStartTimes(List<string> datFilenamesInOrder,
                                                                   DateTime wattbikeSessionStartTime)
        {
            var intervals = datFilenamesInOrder.Select(filename => _datLinesGenerator.CreateIntevalFromDatFile(filename)).ToList();
            
            var activityStartTime = wattbikeSessionStartTime;
            foreach (var interval in intervals)
            {
                interval.ActivityStartTime = activityStartTime;
                activityStartTime = activityStartTime.AddSeconds(interval.TotalTimeSeconds);
            }

            return intervals;
        }
    }
}
