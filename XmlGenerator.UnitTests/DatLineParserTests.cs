using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace XmlGenerator.UnitTests
{
    [TestFixture]
    public class DatLineParserTests
    {
        private string DatFile()
        {
            //"Index	Elapsed time [h:mm:ss.hh]	Elapsed time total [h:mm:ss.hh]	Turns number [Nr]	Cadence [rpm]	Cadence peak [rpm]	Cadence average [rpm]	Circ. pedal velocity [m/s]	Speed [km/h]	Avr speed [km/h]	Distance [m]	Distance total [m]	Heart rate [bpm]	Heart rate peak [bpm]	Heart rate average [bpm]	Force per revolution [N]	Force peak total [N]	Force peak [N]	Avr force [N]	Torque [Nm]	Avr torque [Nm]	Pace/1000m [sec]	Avr pace/1000m [sec]	Power [W]	Power peak [W]	Avr power [W]	Power/Kg [W/Kg]	Avr power/Kg [W/Kg]	Calories [cal]	Calories total [Kcal]	Work [J]	Work total [KJ]	Left leg percent [%]	Total left leg percent [%]	Right leg percent [%]	Total right leg percent [%]	Left time to force peak [mm:ss:00]	Total left time to force peak [mm:ss:00]	Right time to force peak [mm:ss:00]	Total right time to force peak [mm:ss:00]	Left angle to force peak [°]	Total left angle to force peak [°]	Right angle to force peak [°]	Total right angle to force peak [°]
            return @"1	0:00:00.76	0:00:00.76	1	79	79	79	1	30.75401	30.75401	6.49	6.49	95	95	95	86	86	166	86	15	15	01:57.05	01:57.05	121	121	121	2	2	134	0.1	92	0.1	50	50	50	50	00:00.22	00:00.22	00:00.23	00:00.23	102	102	112	112";
        }

        private string DatFileNoHeartData()
        {
            return @"1	0:00:00.76	0:00:00.76	1	79	79	79	1	30.75401	30.75401	6.49	6.49	--	--	--	86	86	166	86	15	15	01:57.05	01:57.05	121	121	121	2	2	134	0.1	92	0.1	50	50	50	50	00:00.22	00:00.22	00:00.23	00:00.23	102	102	112	112";
        }

        [Test]
        public void ParseLine()
        {
            var parser = new DatLineParser();
            var line = parser.ParseLine(DatFile());

            Assert.AreEqual(1, line.Index);
            Assert.AreEqual(new TimeSpan(0,0,0,0,760), line.ElapsedTime);
            Assert.AreEqual(new TimeSpan(0,0,0,0,760), line.ElapsedTimeTotal);
            Assert.AreEqual(1, line.TurnsNumber);
            Assert.AreEqual(79, line.Cadence);
            Assert.AreEqual(79, line.CadenceAverage);
            Assert.AreEqual(79, line.CadencePeak);
            Assert.AreEqual(1, line.CircularPedalVelocity);
            Assert.AreEqual(30.75401, line.Speed);
            Assert.AreEqual(30.75401, line.SpeedAverage);
            Assert.AreEqual(6.49, line.Distance);
            Assert.AreEqual(6.49, line.DistanceTotal);
            Assert.AreEqual(95, line.HeartRate);
            Assert.AreEqual(95, line.HeartRatePeak);
            Assert.AreEqual(95, line.HeartRateAverage);
            Assert.AreEqual(86, line.ForcePerRevolution);
            Assert.AreEqual(86, line.ForcePeakTotal);
            Assert.AreEqual(166, line.ForcePeak);
            Assert.AreEqual(86, line.ForceAverage);
            Assert.AreEqual(15, line.Torque);
            Assert.AreEqual(15, line.TorqueAverage);
            //Assert.AreEqual(new TimeSpan(1,57,050), line.Pace1000m);
            //Assert.AreEqual(new TimeSpan(1,57,050), line.Pace1000mAverage);
            Assert.AreEqual(121, line.Power);
            Assert.AreEqual(121, line.PowerPeak);
            Assert.AreEqual(121, line.PowerAverage);
            Assert.AreEqual(2, line.WattsPerKg);
            Assert.AreEqual(2, line.WattsPerKgAverage);
            Assert.AreEqual(134, line.Calories);
            Assert.AreEqual(0.1, line.CaloriesTotal);
            Assert.AreEqual(92, line.Work);
            Assert.AreEqual(0.1, line.WorkTotal);
        }

        [Test]
        public void HandleNoHeartRateData()
        {
            var parser = new DatLineParser();
            var line = parser.ParseLine(DatFileNoHeartData());
            
            Assert.AreEqual(0, line.HeartRate);
            Assert.AreEqual(0, line.HeartRateAverage);
            Assert.AreEqual(0, line.HeartRatePeak);
        }
    }
}
