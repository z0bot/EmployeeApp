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
    public class AddCompRequest : ServiceRequest
    {
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/comps/";
        public override HttpMethod Method => HttpMethod.Post;
        public Comp Body;

        public AddCompRequest(string theReason, string theItem, string theEmp)
        {
            Body = new Comp
            {
                employee_id = theEmp,
                menuItem_id= theItem,
                reason = theReason,
                
            };
        }
        public static async Task<bool> SendAddCompRequest(string r, string i, string e)
        {
            var sendAddCompRequest = new AddCompRequest(r, i, e);
            var response = await ServiceRequestHandler.MakeServiceCall<UserPostResponse>(sendAddCompRequest, sendAddCompRequest.Body);

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