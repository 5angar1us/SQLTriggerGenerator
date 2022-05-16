using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    public class PatternReader
    {
        private string _patternFolderPath;

        public PatternReader(string patternFolderPath)
        {
            _patternFolderPath = patternFolderPath;
        }

        public string ReadTriggerPart(string fileName)
        {
            string triggerPartPath = Path.Combine(_patternFolderPath, fileName);
            string triggerPart;

            using (StreamReader sr = new StreamReader(triggerPartPath, Encoding.Default, false))
            {
                triggerPart = sr.ReadToEnd().Trim();
            }

            return triggerPart;
        }
    }
}
