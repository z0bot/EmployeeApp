using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    class TableList : RealmObject
    {
        public IList<Table> tables { get; }
    }
}
