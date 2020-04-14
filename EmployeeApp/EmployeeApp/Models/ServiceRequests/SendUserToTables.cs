using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models.ServiceRequests
{
    public class SendUserToTable : ServiceRequest
    {
        public override string Url { get; }
        public override HttpMethod Method => HttpMethod.Put;
        public IList<UpdateTablesWithUser> Body;

        public SendUserToTable(string tableId, string empId)
        {
            Url = "https://dijkstras-steakhouse-restapi.herokuapp.com/tables/" + tableId;

            UpdateTablesWithUser updateIngredientRequestObject = new UpdateTablesWithUser
            {
                propName = "employee_id",
                value = empId,
            };
            Body = new List<UpdateTablesWithUser>();
            Body.Add(updateIngredientRequestObject);
        }

        public static async Task<bool> SendUserRequest(string tableId, string EmpId)
        {
            var senduser = new SendUserToTable(tableId, EmpId );
            var response = await ServiceRequestHandler.MakeServiceCall<DeleteResponse>(senduser, senduser.Body);

            if (response == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class UpdateTablesWithUser
    {
        public string propName { get; set; }
        public string value { get; set; }
    }
}