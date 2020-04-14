using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models.ServiceRequests
{
    class GetTableRequest : ServiceRequest
    {
        public string tableNum;
        //the endpoint we are trying to hit
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/tables/" + tableNum;
        //the type of request
        public override HttpMethod Method => HttpMethod.Get;
        //headers if we ever need them
        public override Dictionary<string, string> Headers => null;
        GetTableRequest()
        {
            tableNum = "";
        }

        GetTableRequest(int table)
        {
            tableNum = table.ToString();
        }

       
        public static async Task<bool> SendGetTableRequest(int tableNum)
        {
            RealmManager.RemoveAll<Order>();
            //make a new request object
            var serviceRequest = new GetTableRequest(tableNum);
            //get a response
            var response = await ServiceRequestHandler.MakeServiceCall<Table>(serviceRequest);

            if(response == null)
            {
                //call failed
                return false;
            }
            else
            {
                Order newOrder = new Order();
                RealmManager.RemoveAll<Order>();
                RealmManager.RemoveAll<Table>();
                //add the response into the local database
                RealmManager.AddOrUpdate<Table>(response);
              
                //call succeeded
                return true;
            }
        }

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
                RealmManager.RemoveAll<TableList>();
                //add the response into the local database
                RealmManager.AddOrUpdate<TableList>(response);

                //call succeeded
                return true;
            }
        }

    }
}
