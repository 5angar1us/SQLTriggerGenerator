using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{

    
    internal class TriggerWriter
    {
        private readonly string textSeparator = " \n -- =================================      ====================================== \n";
        private readonly string header = "use StudentTesting";

        private PatternFactory _patternFactory;
        private TriggerCreator _triggerCreator;

        public TriggerWriter(PatternFactory patternFactory, TriggerCreator triggerCreator)
        {
            _patternFactory = patternFactory;
            _triggerCreator = triggerCreator;
        }

        public void Write(StreamWriter streamWriter, List<Trigger> triggers)
        {
            List<TriggerPatterns> patterns = GetTriggerPatterns();

            streamWriter.WriteLine(header);
            streamWriter.WriteLine(textSeparator);

            triggers.ForEach(trigger =>
            {
                patterns.ForEach(pattern =>
                {
                    string stiggerBody = _triggerCreator.CreateTrigger(trigger, pattern);
                    streamWriter.WriteLine(stiggerBody + Environment.NewLine);
                });
                streamWriter.WriteLine(textSeparator);
            });
        }

        private List<TriggerPatterns> GetTriggerPatterns()
        {
            return new List<TriggerPatterns>()
            {
                _patternFactory.CreateInsertPattern(),
                _patternFactory.GetUpdatePattern(),
                _patternFactory.GetDeletePattern()
            };
        }
    }
}
