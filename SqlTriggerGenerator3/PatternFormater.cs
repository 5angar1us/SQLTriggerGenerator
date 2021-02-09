using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    class PatternFormater
    {
        public string FormatPart(string partName, string text, string specialBody)
        {
            int tabCount = GetTabCount(text, partName);
            specialBody = AddTabs(specialBody, tabCount);
            return specialBody;
        }

        private string AddTabs(string specialBody, int tabCount)
        {
            var rows = specialBody.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 1; i < rows.Count; i++)
            {
                rows[i] = GetTabs(tabCount) + rows[i];
            }

            specialBody = String.Join(Environment.NewLine, rows);
            return specialBody;
        }

        private int GetTabCount(string text, string partName)
        {
            int end = text.IndexOf(partName);
            string x = text.Remove(end, text.Length - end);
            int start = x.LastIndexOf(Environment.NewLine);
            x = x.Remove(0, start);
            x = x.Replace(Environment.NewLine, "");
            int tabCount = x.Length;


            return tabCount;
        }


        private string GetTabs(int count)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append("\t");
            }
            return stringBuilder.ToString();
        }
    }
}
