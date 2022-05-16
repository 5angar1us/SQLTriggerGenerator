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
       
        private static readonly string triggerPatternFolderPath = Path.Combine(GetPath(), FolderNames.TriggerPatterns);
        private static readonly string triggerOutput = Path.Combine(GetPath(), "Init_triggers.sql");

        static void Main(string[] args)
        {
            List<Trigger> triggers = new List<Trigger>();

            triggers.Add(TriggerDataBuilder.Create()
                .SetTableName("Subjects")
                .AddOrderAttribute("id")
                .AddAttribute("Name")
                .Build());

           
            PatternReader reader = new PatternReader(triggerPatternFolderPath);
            PatternFactory patternFactory = new PatternFactory(reader);
            TriggerCreator triggerCreator = new TriggerCreator();

            using (StreamWriter streamWriter = new StreamWriter(triggerOutput, append: false,Encoding.Default))
            {
                TriggerWriter writer = new TriggerWriter(patternFactory, triggerCreator);
                writer.Write(streamWriter, triggers);
            }
            //to do сделать получение пути из результирующего файла из консоли
            //to do сделать получени информации о таблицах и их атрибутов из файла
        }
        private static string GetPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
