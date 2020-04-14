using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Models
{
    class UserList : RealmObject
    {
        public IList<User> users { get; }
    }
}
