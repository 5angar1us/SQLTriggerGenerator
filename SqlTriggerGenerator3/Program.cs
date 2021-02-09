using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    class Program
    {
        private static readonly string splisText = " \n -- =================================      ====================================== \n";
        private static readonly string triggerPath = Path.Combine(GetPath(), @"я.SQL scripts\ProtocolTrigger.sql");

        static void Main(string[] args)
        {
            List<TriggerData> triggers = new List<TriggerData>();

            triggers.Add(TriggerDataBuilder.Create()
                .SetTableName("Subjects")
                .AddOrderAttribute("id")
                .AddAttribute("Name")
                .Build());

           
          
            PatternFactory patternFactory = new PatternFactory(GetPath());
            TriggerPattern insertPattern = patternFactory.GetInsertPattern();
            TriggerPattern updatePattern = patternFactory.GetUpdatePattern();
            TriggerPattern deletePattern = patternFactory.GetDeletePattern();

            TriggerCreator triggerCreator = new TriggerCreator();

            using (StreamWriter sw = new StreamWriter(triggerPath, false, Encoding.Default))
            {
                sw.WriteLine("use StudentTesting");
                sw.WriteLine(splisText);
                triggers.ForEach(o =>
                {
                    sw.WriteLine(triggerCreator.CreateTrigger(o, insertPattern) + Environment.NewLine);
                    sw.WriteLine(triggerCreator.CreateTrigger(o, updatePattern) + Environment.NewLine);
                    sw.WriteLine(triggerCreator.CreateTrigger(o, deletePattern) + Environment.NewLine);
                    sw.WriteLine(splisText);
                });

            }

        }
        private static string GetPath()
        {
            DirectoryInfo directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            string path = directory.FullName;
            return path;
        }
    }
}
