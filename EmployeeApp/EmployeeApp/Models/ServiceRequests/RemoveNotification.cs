using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using EmployeeApp.Pages;

namespace EmployeeApp.Models.ServiceRequests
{
    /// Post request to add a new user to the server
    public class RemoveNotification : ServiceRequest
    {
        string id;
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/notifications/" +id;
        public override HttpMethod Method => HttpMethod.Delete;

        public RemoveNotification(string notifId)
        {
            id = notifId;
        }
        public static async Task<bool> SendRemoveNotification(string notifId)
        {
            var sendRemoveNotification = new RemoveNotification(notifId);
            var response = await ServiceRequestHandler.MakeServiceCall<UserPostResponse>(sendRemoveNotification);

            if (response.message == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}