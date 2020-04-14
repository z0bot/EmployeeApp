using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Models
{
    public class NotificationList : RealmObject
    {
        public IList<Notifications> notifications { get; }

    }
}
