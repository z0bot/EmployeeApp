using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models.ServiceRequests
{
    class GetEmpTablesRequest : ServiceRequest
    {
        public string tableNum;
        //the endpoint we are trying to hit
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/tables/employeeview/" + tableNum;
        //the type of request
        public override HttpMethod Method => HttpMethod.Get;
        //headers if we ever need them
        public override Dictionary<string, string> Headers => null;


        GetEmpTablesRequest(int table)
        {
            tableNum = table.ToString();
        }


        public static async Task<bool> SendGetEmpTablesRequest(int tableNum)
        {
            //make a new request object
            var serviceRequest = new GetEmpTablesRequest(tableNum);
            //get a response
            var response = await ServiceRequestHandler.MakeServiceCall<EmpTables>(serviceRequest);

            if (response == null)
            {
                //call failed
                return false;
            }
            else
            {
                RealmManager.RemoveAll<EmpTables>();
                //add the response into the local database
                RealmManager.AddOrUpdate<EmpTables>(response);

                //call succeeded
                return true;
            }
        }

    }
}
