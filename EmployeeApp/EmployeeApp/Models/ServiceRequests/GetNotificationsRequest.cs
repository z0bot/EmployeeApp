using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeApp.Models.ServiceRequests
{
    public class GetNotificationsRequest : ServiceRequest
    {
        public string empId;
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/notifications/"+empId;
        public override HttpMethod Method => HttpMethod.Get;

        //May need to include employee id
        public GetNotificationsRequest(string id)
        {
            empId = id;
        }
        public static async Task<bool> SendNotificationRequest(string employeeid)
        {
            var sendNotificationRequest = new GetNotificationsRequest(employeeid);
            var response = await ServiceRequestHandler.MakeServiceCall<NotificationList>(sendNotificationRequest);
            if(response==null)
            {
                return false;
            }
           
            else
            {
                RealmManager.RemoveAll<NotificationList>();
                RealmManager.AddOrUpdate<NotificationList>(response);
                return true;
            }
        }
     
    }
}
