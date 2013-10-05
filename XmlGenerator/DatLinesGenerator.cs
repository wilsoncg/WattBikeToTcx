using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlGenerator
{
    public class DatLinesGenerator
    {
        public virtual DatLines CreateIntevalFromDatFile(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                var headers = sr.ReadLine();
                var contents = sr.ReadToEnd().Split('\n');
                var interval = new DatParser().Parse(contents);

                return interval;
            }
        }
    }
}
