using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace XmlGenerator
{
    public class DatLineParser
    {
        public DatLine ParseLine(string datLine)
        {
            var line = datLine.Split('\t');
            var index = int.Parse(line[(int)Line.Index]);
            var elapsedTime = TimeSpan.Parse(line[(int)Line.ElapsedTime]);
            var elapsedTimeTotal = TimeSpan.Parse(line[(int)Line.ElapsedTimeTotal]);
            var turnsNumber = int.Parse(line[(int)Line.TurnsNumber]);
            var cadence = int.Parse(line[(int) Line.Cadence]);
            var cadenceAverage = int.Parse(line[(int) Line.CadenceAverage]);
            var cadencePeak = int.Parse(line[(int) Line.CadencePeak]);
            var circularPedalVelocity = int.Parse(line[(int) Line.CircPedalVelocity]);
            var speed = decimal.Parse(line[(int) Line.Speed]);
            var speedAverage = decimal.Parse(line[(int) Line.SpeedAverage]);
            var distance = decimal.Parse(line[(int) Line.Distance]);
            var distanceTotal = decimal.Parse(line[(int) Line.DistanceTotal]);
            int heartRate;
            int.TryParse(line[(int) Line.HeartRate], out heartRate);
            int heartRateAverage;
            int.TryParse(line[(int) Line.HeartRateAverage], out heartRateAverage);
            int heartRatePeak;
            int.TryParse(line[(int) Line.HeartRatePeak], out heartRatePeak);
            var forcePerRevolution = int.Parse(line[(int) Line.ForcePerRevolution]);
            var forcePeak = int.Parse(line[(int) Line.ForcePeak]);
            var forcePeakTotal = int.Parse(line[(int) Line.ForcePeakTotal]);
            var forceAverage = int.Parse(line[(int) Line.ForceAverage]);
            var torque = int.Parse(line[(int) Line.Torque]);
            var torqueAverage = int.Parse(line[(int) Line.TorqueAverage]);
            var dateTimeFormatInfo = new DateTimeFormatInfo();
            dateTimeFormatInfo.ShortTimePattern = "mm:ss.tt";
            TimeSpan pace1000m;
            TimeSpan.TryParse(line[(int) Line.Pace1000m], dateTimeFormatInfo, out pace1000m);
            TimeSpan pace1000mAverage;
            TimeSpan.TryParse(line[(int) Line.Pace1000mAverage], dateTimeFormatInfo, out pace1000mAverage);
            var power = int.Parse(line[(int) Line.Power]);
            var powerPeak = int.Parse(line[(int) Line.PowerPeak]);
            var powerAverage = int.Parse(line[(int) Line.PowerAverage]);
            var wattsPerKg = decimal.Parse(line[(int) Line.WattsPerKg]);
            var wattsPerKgAverage = decimal.Parse(line[(int) Line.WattsPerKgAverage]);
            var calories = int.Parse(line[(int) Line.Calories]);
            var caloriesTotal = decimal.Parse(line[(int) Line.CaloriesTotal]);
            var work = int.Parse(line[(int) Line.Work]);
            var workTotal = decimal.Parse(line[(int) Line.WorkTotal]);
             
            return new DatLine
                {
                    Index = index,
                    ElapsedTime = elapsedTime,
                    ElapsedTimeTotal = elapsedTimeTotal,
                    TurnsNumber = turnsNumber,
                    Cadence = cadence,
                    CadenceAverage = cadenceAverage,
                    CadencePeak = cadencePeak,
                    CircularPedalVelocity = circularPedalVelocity,
                    Speed = speed,
                    SpeedAverage = speedAverage,
                    Distance = distance,
                    DistanceTotal = distanceTotal,
                    HeartRate = heartRate,
                    HeartRateAverage = heartRateAverage,
                    HeartRatePeak = heartRatePeak,
                    ForceAverage = forceAverage,
                    ForcePeakTotal = forcePeakTotal,
                    ForcePeak = forcePeak,
                    ForcePerRevolution = forcePerRevolution,
                    Torque = torque,
                    TorqueAverage = torqueAverage,
                    Pace1000m = pace1000m,
                    Pace1000mAverage = pace1000mAverage,
                    Power = power,
                    PowerAverage = powerAverage,
                    PowerPeak = powerPeak,
                    WattsPerKg = wattsPerKg,
                    WattsPerKgAverage = wattsPerKgAverage,
                    Calories = calories,
                    CaloriesTotal = caloriesTotal,
                    Work = work,
                    WorkTotal = workTotal
                };
        }
    }

    public enum Line
    {
        Index = 0,
        ElapsedTime,
        ElapsedTimeTotal,
        TurnsNumber,
        Cadence, //rpm
        CadencePeak, //rpm
        CadenceAverage, //rpm
        CircPedalVelocity,
        Speed, //kmh
        SpeedAverage, //khm
        Distance, //m
        DistanceTotal, //m
        HeartRate, //bpm
        HeartRatePeak, //bpm
        HeartRateAverage, //bpm
        ForcePerRevolution, //N
        ForcePeakTotal, //N
        ForcePeak, //N
        ForceAverage, //N
        Torque, //Nm
        TorqueAverage, //Nm
        Pace1000m, //sec
        Pace1000mAverage, //sec
        Power, //watts
        PowerPeak,
        PowerAverage,
        WattsPerKg,
        WattsPerKgAverage,
        Calories, //cal
        CaloriesTotal, //kcal
        Work, //joules
        WorkTotal, //kjoules
        LeftLegPercent,
        LeftLegPercentTotal,
        RightLegPercent,
        RightLegPercentTotal,
        LeftTimeToForcePeak,
        LeftTimeToForcePeakTotal,
        RightTimeToForcePeak,
        RightTimeToForcePeakTotal,
        LeftAngleToForcePeak, //degrees
        LeftAngleToForcePeakTotal, //degrees
        RightAngleToForcePeak, //degrees
        RightAngleToForcePeakTotal, //degrees
    }
}
