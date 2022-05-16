using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    class TriggerCreator
    {
        public TriggerCreator()
        {


        }

        public string CreateTrigger(Trigger trigger, TriggerPatterns triggerPattern)
        {
            string specificMainPart = CreateSpecificMainPart(trigger, triggerPattern);

            StringBuilder triggerBody = new StringBuilder(triggerPattern.MainBody.Clone() as string);

            PatternFormater patternFormater = new PatternFormater();

            string specificInitBody = patternFormater.FormatPart(SpecialInitBody, triggerBody.ToString(), triggerPattern.SpecificInitBody);
            triggerBody.Replace(SpecialInitBody, specificInitBody);

            string specificBody = patternFormater.FormatPart(SpecialMainBody, triggerBody.ToString(), specificMainPart);
            triggerBody.Replace(SpecialMainBody, specificBody);

            triggerBody.Replace(TableName, trigger.TableName);
            triggerBody.Replace(OperationType, triggerPattern.OperationName);

            return triggerBody.ToString();
        }

        private static readonly string Attribute = FormatTag(TagNames.Attribute);
        private static readonly string OrderAttribute = FormatTag(TagNames.OrderAttribute);
        private static readonly string SpecialInitBody = FormatTag(TagNames.SpecialInitBody);
        private static readonly string SpecialMainBody = FormatTag(TagNames.SpecialMainBody);
        private static readonly string TableName = FormatTag(TagNames.TableName);
        private static readonly string OperationType = FormatTag(TagNames.OperationType);

        private static string FormatTag(string tag) => $"<{tag}>";
        private static string CreateSpecificMainPart(Trigger trigger, TriggerPatterns triggerPattern)
        {
            StringBuilder builder = new StringBuilder();

            foreach(var atribute in trigger.Attributes)
            {
                string attribyteBody = 
                    (triggerPattern.AttributeBody.Clone() as string)
                    .Replace(Attribute, atribute.Name);

                builder.Append(attribyteBody + Environment.NewLine);
            }

            builder.Replace(OrderAttribute, trigger.OrderAttribute.Name);

            return builder.ToString();
        }
    }
}
