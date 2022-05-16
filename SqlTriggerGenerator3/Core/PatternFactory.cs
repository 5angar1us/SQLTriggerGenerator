using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    partial class PatternFactory
    {
        private PatternReader _reader;

        public PatternFactory(PatternReader reader)
        {
            _reader = reader;

            _mainBodyLazy = new Lazy<string>(() =>
              _reader.ReadTriggerPart(FileNames.MainPartPatternFileName)
           );
        }

        public TriggerPatterns CreateInsertPattern()
        {
            return CreatePattern(ETriggerType.Insert);
        }
        public TriggerPatterns GetUpdatePattern()
        {
            return CreatePattern(ETriggerType.Update);
        }
        public TriggerPatterns GetDeletePattern()
        {
            return CreatePattern(ETriggerType.Delete);
        }

        private string MainBody { get { return _mainBodyLazy.Value; } }

        private readonly Lazy<string> _mainBodyLazy;
        private TriggerPatterns CreatePattern(ETriggerType triggerType)
        {

            (string specialIntiBodyFileName,string specialMainBodyFileName )= GetSpeciaBodyPartlFileNames(triggerType);
            
            string specialInitBody = _reader.ReadTriggerPart(specialIntiBodyFileName);
            string specialMainBody = _reader.ReadTriggerPart(specialMainBodyFileName);

            TriggerPatterns triggerPattern = new TriggerPatterns(triggerType.GetName(), MainBody, specialMainBody, specialInitBody);

            return triggerPattern;
        }

        private (string SpecialInitBody, string SpecialMainBody) GetSpeciaBodyPartlFileNames(ETriggerType triggerType)
        {
            if (triggerType == ETriggerType.Insert)
            {
                return (FileNames.InsertSpecialInitBodyFileName, FileNames.InsertSpecialMainBodyFileName);
            }
            else if (triggerType == ETriggerType.Update)
            {
                return (FileNames.UpdateSpecialInitBodyFileName, FileNames.UpdateSpecialMainBodyFileName);
            }
            else if (triggerType == ETriggerType.Delete)
            {
                return (FileNames.DeleteSpecialInitBodyFileName, FileNames.DeleteSpecialMainBodyFileName);
            }
            else throw new ArgumentException(nameof(triggerType));

        }
    }
}
