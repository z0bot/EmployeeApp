using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Models
{
    public class Comp : RealmObject
    {
        public string employee_id { get; set; }
        public string menuItem_id { get; set; }
        public string reason { get; set; }
    }
}
