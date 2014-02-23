using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlGenerator
{
    // each line represents a pedal revolution
    public class DatLine
    {
        public int Index;
        public TimeSpan ElapsedTime;
        public TimeSpan ElapsedTimeTotal;
        public int TurnsNumber;
        public int Cadence; //rpm
        public int CadencePeak; //rpm
        public int CadenceAverage; //rpm
        public int CircularPedalVelocity; //m/s
        public decimal Speed; //kmh
        public decimal SpeedAverage; //kmh
        public decimal Distance; //m
        public decimal DistanceTotal; //m
        public int HeartRate; //bpm
        public int HeartRatePeak; //bpm
        public int HeartRateAverage; //bpm
        public int ForcePerRevolution; //N
        public int ForcePeakTotal; //N
        public int ForcePeak; //N
        public int ForceAverage; //N
        public int Torque; //Nm
        public int TorqueAverage; //Nm
        public TimeSpan Pace1000m; //sec
        public TimeSpan Pace1000mAverage; //sec
        public int Power; //watts
        public int PowerPeak;
        public int PowerAverage;
        public decimal WattsPerKg;
        public decimal WattsPerKgAverage;
        public int Calories; //cal
        public decimal CaloriesTotal; //kcal
        public int Work; //joules
        public decimal WorkTotal; //joules
        public int LeftLegPercent;
        public int LeftLegPercentTotal;
        public int RightLegPercent;
        public int RightLegPercentTotal;
        public TimeSpan LeftTimeToForcePeak;
        public TimeSpan LeftTimeToForcePeakTotal;
        public TimeSpan RightTimeToForcePeak;
        public TimeSpan RightTimeToForcePeakTotal;
        public int LeftAngleToForcePeak; //degrees
        public int LeftAngleToForcePeakTotal; //degrees
        public int RightAngleToForcePeak; //degrees
        public int RightAngleToForcePeakTotal; //degrees
    }
}
