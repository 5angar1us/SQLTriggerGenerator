using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    public class Trigger
    {
        public List<SqlАttribyte> Attributes { set; get;  }

        public SqlАttribyte OrderAttribute { set; get; }
        public string TableName { set; get; }

        public Trigger()
        {
            Attributes = new List<SqlАttribyte>();
        }
    }
}
