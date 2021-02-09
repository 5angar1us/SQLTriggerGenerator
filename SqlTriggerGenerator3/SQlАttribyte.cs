using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerGenerator2
{
    public class SqlАttribyte
    {
        public SqlАttribyte(string name)
        {
            Name = name;
            OrderItem = false;
        }

        public SqlАttribyte(string name, bool orderItem)
        {
            Name = name;
            OrderItem = orderItem;
        }

        public string Name { private set; get; }
        public bool OrderItem { private set; get; }
    }
}
