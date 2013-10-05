using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlGenerator
{
    public class DatParser
    {
        public DatLines Parse(string[] lines)
        {
            var datLines = new DatLines();
            var lineParser = new DatLineParser();
            foreach (var line in lines)
            {
                if(!string.IsNullOrEmpty(line))
                {
                    var datLine = lineParser.ParseLine(line);
                    datLines.Add(datLine);
                }
            }
            return datLines;
        }
    }
}
