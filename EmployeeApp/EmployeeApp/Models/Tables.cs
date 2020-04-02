using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Models
{
    class Tables : RealmObject
    {

        [PrimaryKey]
        public string _id { get; set; }
        public int table_number { get; set; }
        public string employee_id { get; set; }
        
    }
}
