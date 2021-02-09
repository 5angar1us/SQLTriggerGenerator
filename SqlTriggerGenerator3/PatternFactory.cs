using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    class PatternFactory
    {
        private string _direcoryPath;
        private string _path = @"я.SQL scripts\TriggersPatterns";

        private string mainBody;
        public PatternFactory(string direcoryPath)
        {
            _direcoryPath = direcoryPath;

            string MainPartPatternPath = Path.Combine($@"\{_path}", "MainPartTriggerPattern.sql");
            using (StreamReader sr = new StreamReader(MainPartPatternPath, Encoding.Default, false))
            {
                mainBody = sr.ReadToEnd().Trim();
            }
        }

        public TriggerPattern GetInsertPattern()
        {
            return GetPattern("Insert");
        }
        public TriggerPattern GetUpdatePattern()
        {
            return GetPattern("Update");
        }
        public TriggerPattern GetDeletePattern()
        {
            return GetPattern("Delete");
        }

        private TriggerPattern GetPattern(string operationName)
        {
            string SpecialInitBody;
            string SpecialMainBody;



            string SpecialInitBodyPath = Path.Combine($@"\{_path}", $"{operationName}SpecialInitBody.sql");
            using (StreamReader sr = new StreamReader(SpecialInitBodyPath, Encoding.Default, false))
            {
                SpecialInitBody = sr.ReadToEnd().Trim();
            }

            string SpecialMainBodyPath = Path.Combine($@"\{_path}", $"{operationName}SpecialMainBody.sql");
            using (StreamReader sr = new StreamReader(SpecialMainBodyPath, Encoding.Default, false))
            {
                SpecialMainBody = sr.ReadToEnd().Trim();
            }

            TriggerPattern triggerPattern = new TriggerPattern(operationName, mainBody, SpecialMainBody, SpecialInitBody);

            return triggerPattern;
        }
    }
}
