using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace XmlGenerator.UnitTests
{
    [TestFixture]
    public class IntervalsGeneratorTests
    {
        [Test]
        public void UseDatLinesGeneratorToCreateOneCorrectInterval()
        {
            var datLinesGenerator = MockRepository.GenerateMock<DatLinesGenerator>();
            var filename1 = "file1.dat";
            var filenames = new List<string> { filename1 };
            var seconds = new TimeSpan(0, 0, 100);
            var interval1 = new DatLines();
            interval1.Add(new DatLine {ElapsedTimeTotal = seconds});
            datLinesGenerator.Expect(x => x.CreateIntevalFromDatFile(filename1)).Return(interval1);
            var sessionStartTime = new DateTime(2000, 1, 1, 12, 0, 0);

            var generator = new IntervalsGenerator(datLinesGenerator);
            var result = generator.CreateIntervalsWithCorrectStartTimes(filenames, sessionStartTime);

            Assert.AreEqual(sessionStartTime, result.First().ActivityStartTime);
        }

        [Test]
        public void UseDatLinesGeneratorToGetIntervalsWithCorrectStartTimes()
        {
            var datLinesGenerator = MockRepository.GenerateMock<DatLinesGenerator>();
            var filename1 = "file1.dat";
            var filename2 = "file2.dat";
            var filenames = new List<string> {filename1, filename2};
            var seconds = new TimeSpan(0, 0, 100);
            var interval1 = new DatLines();
            interval1.Add(new DatLine { ElapsedTimeTotal = seconds });
            var interval2 = new DatLines();
            interval2.Add(new DatLine { ElapsedTimeTotal = seconds });
            datLinesGenerator.Expect(x => x.CreateIntevalFromDatFile(filename1)).Return(interval1);
            datLinesGenerator.Expect(x => x.CreateIntevalFromDatFile(filename2)).Return(interval2);
            var sessionStartTime = new DateTime(2000, 1, 1, 12, 0, 0);
            var secondIntervalStartTime = sessionStartTime.AddSeconds(100);

            var generator = new IntervalsGenerator(datLinesGenerator);
            var result = generator.CreateIntervalsWithCorrectStartTimes(filenames, sessionStartTime);

            Assert.IsTrue(result.Count == 2);
            Assert.AreEqual(sessionStartTime, result.ElementAt(0).ActivityStartTime);
            Assert.AreEqual(secondIntervalStartTime, result.ElementAt(1).ActivityStartTime);
        }
    }
}
