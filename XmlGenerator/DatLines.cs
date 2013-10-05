using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlGenerator
{
    public class DatLines
    {
        public DateTime ActivityStartTime;

        private List<DatLine> _lines; 
        public List<DatLine> Lines
        {
            get
            {
                if (_lines == null)
                {
                    _lines = new List<DatLine>();
                }
                return _lines;
            }
        }

        public byte AverageHeartRateBpm
        {
            get { return (byte)_lines.Last().HeartRateAverage; }
        }

        public ushort Calories
        {
            get { return (ushort)_lines.Last().CaloriesTotal; }
        }

        public double TotalTimeSeconds
        {
            get { return Lines.Last().ElapsedTimeTotal.TotalSeconds; }
        }

        public double Distance
        {
            get
            {
                return (double)_lines.Last().DistanceTotal;
            }
        }

        public byte MaximumHeartRate
        {
            get { return (byte)_lines.Last().HeartRatePeak; }
        }

        public byte AverageCadence
        {
            get { return (byte)_lines.Last().CadenceAverage; }
        }

        public void Add(DatLine datLine)
        {
            if (_lines == null)
            {
                _lines = new List<DatLine>();
            }
            _lines.Add(datLine);
        }
    }
}
