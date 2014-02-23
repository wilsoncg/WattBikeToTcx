using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using XmlGenerator;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Escape (Esc) key to quit.");
            Run();
            Console.WriteLine();
            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.Escape);
            Console.WriteLine();
            Console.WriteLine("Exiting...");
        }

        private static void Run()
        {
            var filenames = new List<string>
                {
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval1.dat",
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval2.dat",
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval3.dat",
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval4.dat",
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval5.dat",
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval6.dat",
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval7.dat",
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval8.dat",
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval9.dat",
                    "C:\\Users\\Craig\\Documents\\wattbike\\12022014_1803_interval10.dat",
                };

            var activityStartTime = new DateTime(2014, 02, 12, 18, 03, 0, DateTimeKind.Utc);
            var filename = activityStartTime.ToString("ddMMyy_HHmm");
            var tcxFilename = string.Format("C:\\Users\\Craig\\Documents\\wattbike\\{0}.tcx", filename);
            var intervals = new IntervalsGenerator().CreateIntervalsWithCorrectStartTimes(filenames, activityStartTime);
            var trainingCenter = new TrainingCenterGenerator().Generate(intervals, activityStartTime);
            
            var serializer = new XmlSerializer(typeof(TrainingCenterDatabase_t), "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2");
            FileStream fs = new FileStream(tcxFilename, FileMode.Create);
            TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
                
            Console.WriteLine("Creating tcx file...");
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("","");
            xmlSerializerNamespaces.Add("", "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2");
            xmlSerializerNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            serializer.Serialize(writer, trainingCenter, xmlSerializerNamespaces);
            writer.Close();

            // Create the XmlSchemaSet class.
            XmlSchemaSet sc = new XmlSchemaSet();

            // Add the schema to the collection.
            sc.Add("http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2", "http://www.garmin.com/xmlschemas/TrainingCenterDatabasev2.xsd");

            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += OnValidationEventHandler;

            Console.WriteLine("Tcx file {0} created.", tcxFilename);
            // Create the XmlReader object.
            //XmlReader reader = XmlReader.Create(tcxFilename, settings);

            // Parse the file. 
            //while (reader.Read()) ;
        }

        private static void OnValidationEventHandler(object sender, ValidationEventArgs args)
        {
            switch (args.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Validation error: {0}", args.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Validation warning: {0}", args.Message);
                    break;
            }
        }

        //var stopWatch = new Stopwatch();
        //Console.WriteLine("Parsing dat file...");
        //stopWatch.Start();
        //stopWatch.Stop();
        //Console.WriteLine("Parsing dat file took {0}ms", stopWatch.ElapsedMilliseconds);
        //Console.WriteLine("Generating activity from dat file contents...");
        //        stopWatch.Reset();
        //        stopWatch.Start();
        //stopWatch.Stop();
        //        Console.WriteLine("Generating took {0}ms", stopWatch.ElapsedMilliseconds);
    }
}
