using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    class TriggerCreator
    {
        private static readonly string ATTRIBUTE = "<Attribute>";
        private static readonly string ORDER_ATTRIBUTE = "<OrderAttribute>";
        private static readonly string SPECIAL_INIT_BODY = "<SpecialInitBody>";
        private static readonly string SPECIAL_MAIN_BODY = "<SpecialMainBody>";
        private static readonly string TABLE_NAME = "<TableName>";
        private static readonly string OPERATION_TYPE = "<OperationType}>";


        public TriggerCreator()
        {


        }

        public string CreateTrigger(TriggerData trigger, TriggerPattern triggerPattern)
        {
            StringBuilder specificMainPart = new StringBuilder();
            StringBuilder attribyteBody;

            trigger.Attributes.ForEach(o =>
            {
                attribyteBody = new StringBuilder(triggerPattern.AttributeBody.Clone() as string);
                attribyteBody.Replace(ATTRIBUTE, o.Name);
                specificMainPart.Append(attribyteBody.ToString() + Environment.NewLine);
            });
            specificMainPart.Replace(ORDER_ATTRIBUTE, trigger.OrderAttribute.Name);

            StringBuilder triggerBody = new StringBuilder(triggerPattern.MainBody.Clone() as string);

            PatternFormater patternFormater = new PatternFormater();

            string specificInitBody = patternFormater.FormatPart(SPECIAL_INIT_BODY, triggerBody.ToString(), triggerPattern.SpecificInitBody);
            triggerBody.Replace(SPECIAL_INIT_BODY, specificInitBody);

            string specificBody = patternFormater.FormatPart(SPECIAL_MAIN_BODY, triggerBody.ToString(), specificMainPart.ToString());
            triggerBody.Replace(SPECIAL_MAIN_BODY, specificBody);

            triggerBody.Replace(TABLE_NAME, trigger.TableName);
            triggerBody.Replace(OPERATION_TYPE, triggerPattern.OperationName);

            return triggerBody.ToString();
        }

    }
}
