using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    public class TriggerDataBuilder
    {
        Trigger trigger;

        private TriggerDataBuilder()
        {
            trigger = new Trigger();
        }

        public TriggerDataBuilder AddAttribute(string attributeName)
        {
            trigger.Attributes.Add(new SqlАttribyte(attributeName));
            return this;
        }

        public  TriggerDataBuilder AddOrderAttribute(string attributeName)
        {
            var orderAttribute = new SqlАttribyte(attributeName, orderItem: true);
            trigger.OrderAttribute = orderAttribute;
            trigger.Attributes.Add(orderAttribute);
            return this;
        }


        public  TriggerDataBuilder SetTableName(string tableName)
        {
            trigger.TableName = tableName;
            return this;
        }

        public Trigger Build()
        {
            return trigger;
        }


        public static TriggerDataBuilder Create()
        {
            return new TriggerDataBuilder();
        }
    }
}
