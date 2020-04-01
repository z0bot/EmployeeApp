using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Models
{
    class User : RealmObject
    {
        
        [PrimaryKey]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}