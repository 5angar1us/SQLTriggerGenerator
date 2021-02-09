using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    class TriggerPattern
    {
        public string OperationName { private set; get; }
        public string MainBody { private set; get; }
        public string AttributeBody { private set; get; }
        public string SpecificInitBody { private set; get; }

        public TriggerPattern(string operationName, string mainBody, string specificMainBody, string specificInitBody)
        {
            OperationName = operationName;
            MainBody = mainBody;
            AttributeBody = specificMainBody;
            SpecificInitBody = specificInitBody;
        }
    }
}
