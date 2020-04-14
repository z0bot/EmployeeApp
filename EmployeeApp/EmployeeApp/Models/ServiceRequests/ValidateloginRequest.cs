using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models.ServiceRequests
{
    public class ValidateLoginRequest : ServiceRequest
    {
        public override string Url { get; }
        public override HttpMethod Method => HttpMethod.Post;
        public ValidateLoginRequestBody Body { get; set; }

        public ValidateLoginRequest(string userName, string passWord)
        {
            Url = "https://dijkstras-steakhouse-restapi.herokuapp.com/Employees/Authentication";

            ValidateLoginRequestBody validateLoginRequestBody = new ValidateLoginRequestBody
            {
                username = userName,
                password = passWord
            };
            Body = validateLoginRequestBody;
        }

        public static async Task<bool> SendValidateLoginRequest(string userName, string passWord)
        {
            var sendValidateLoginRequest = new ValidateLoginRequest(userName, passWord);
            var response = await ServiceRequestHandler.MakeServiceCall<ValidateLoginRequestResponse>(sendValidateLoginRequest, sendValidateLoginRequest.Body);

            if (response.employee == null && response.message != null)
            {
                return false;
            }
            else
            {
                RealmManager.AddOrUpdate<Employee>(response.employee);
                return true;
            }
        }
    }

    public class ValidateLoginRequestBody
    {
        public string username { get; set; }
        public string password { get; set; }
    }

       class ValidateLoginRequestResponse
    {
        public Employee employee { get; set; }
        public string message { get; set; }
    }
}