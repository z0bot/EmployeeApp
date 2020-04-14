using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Models
{
    public class EmpUser : RealmObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}
