using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.XmlDiffPatch;
using NUnit.Framework;

namespace XmlGenerator.UnitTests
{
    [TestFixture]
    public class TrackPointGeneratorTests
    {
        [Test]
        public void SpeedAndWattsAreSetInTrackpoint()
        {
            var speed = 1;
            var watts = 2;
            var activityStartTime = new DateTime();
            var datLine = new DatLine { Speed = speed, Power = watts };
            
            //var expectedExtensions = new XmlElement[] { new  }
            var generator = new TrackPointGenerator();
            var trackpoint = generator.Generate(datLine, activityStartTime);

            //var xmlDiff = new XmlDiff().Compare()

            //Assert.AreEqual(expectedExtensions, trackpoint.Extensions.Any);
        }
    }
}
