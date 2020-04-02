using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models.ServiceRequests
{
    public class GetTableRequest : ServiceRequest
    {
        //the endpoint we are trying to hit
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/tables";
        //the type of request
        public override HttpMethod Method => HttpMethod.Get;
        //headers if we ever need them
        public override Dictionary<string, string> Headers => null;

        public static async Task<bool> SendGetTableRequest()
        {
            //make a new request object
            var serviceRequest = new GetTableRequest();
            //get a response
            var response = await ServiceRequestHandler.MakeServiceCall<TableList>(serviceRequest);
             

            if (response == null)
            {
                //call failed
                return false;
            }
            else
            {
                //add the response into the local database
                RealmManager.AddOrUpdate<TableList>(response);
                //call succeeded
                return true;
            }
        }
    }
}
