using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace EmployeeApp.Models
{
    class EmpTables : RealmObject
    {
        [PrimaryKey]
        public string _id { get; set; }

        public int table_number { get; set; }

        public string employee_id { get; set; }

        public Order order_id { get; set; }

        public string tableNumberString => "Table " + table_number.ToString();
    }
};
