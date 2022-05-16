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
            var rows = specialBody
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int row = 1; row < rows.Count; row++)
            {
                rows[row] = CreateLineOfTabs(tabCount) + rows[row];
            }

            specialBody = String.Join(Environment.NewLine, rows);
            return specialBody;
        }

        private string CreateLineOfTabs(int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException("count");

            IEnumerable<string> tabs = Enumerable.Range(0, count).Select(x => "\t");

            return String.Join("", tabs);
        }

        private int GetTabCount(string text, string partName)
        {
            string sourceText = text.Clone() as string;

            string formatCharacters = GetTargetFormatCharacters(sourceText, partName);
            string tabCharacters = ClearningUnwantedCharacters(formatCharacters);

            int tabCount = tabCharacters.Length;

            return tabCount;
        }

        private string ClearningUnwantedCharacters(string formatCharacters)
        {
            return formatCharacters.Replace(Environment.NewLine, "");
        }

        private string GetTargetFormatCharacters(string text, string partName)
        {
            int end = text.IndexOf(partName);

            string targetText = text.Substring(0, end);

            int start = targetText.LastIndexOf(Environment.NewLine);

            return targetText.Substring(start);
        }
    }
}
