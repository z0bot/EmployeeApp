using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows;
using Realms;
using EmployeeApp.Models;
using EmployeeApp.Models.ServiceRequests;

namespace EmployeeApp.Pages
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            tableSelector.Title = "Select Section";
            tableSelector.TextColor = Color.White;
            tableSelector.SelectedIndex = 0;
            

        }
        public async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            if (uName.Text == null || pWord.Text == null || tableSelector.SelectedIndex == -1)
            {
                await DisplayAlert("Login Error", "User ID, Password fields and Section must not be blank", "Ok");

            }
            else
            {
                ValidateEmployee(uName.Text, pWord.Text);

            }

        }
        public async void ValidateEmployee(string uName, string pWord)
        {
            RealmManager.RemoveAll<Employee>();
            var validLoginRequest = await ValidateLoginRequest.SendValidateLoginRequest(uName, pWord);
            if (validLoginRequest)
            {
                EmpUser currentUser = new EmpUser
                {
                    UserName = uName,
                    Password = pWord,
                };

                RealmManager.RemoveAll<Order>();
                RealmManager.RemoveAll<Table>();
                MyGlobals.MySection = tableSelector.SelectedIndex;
                RealmManager.RemoveAll<EmpUser>();
                RealmManager.AddOrUpdate<EmpUser>(currentUser);
                LoadUserToTables(tableSelector.SelectedIndex, RealmManager.All<Employee>().FirstOrDefault()._id);
                await Navigation.PushAsync(new alertPage());
            }
            else
            {
                await DisplayAlert("Authentification Failed", "If you continue to have trouble logging in speak with your manager.", "Ok");
            }
        }

        public async void LoadUserToTables(int selected, string empId)
        {
            var newTable = new List<Table>();
            var newTable1 = new List<Table>();
            var tryit = await GetTableRequest.SendGetTableRequest();

            newTable = RealmManager.All<TableList>().FirstOrDefault().tables.Where<Table>((Table m) => m.table_number > 10).ToList();
            newTable1 = RealmManager.All<TableList>().FirstOrDefault().tables.Where<Table>((Table m) => m.table_number < 11).ToList();
            string[] tableIds = new string[10];
            string[] tableIds1 = new string[10];
            bool sent = new bool();

            for (int i = 0; i < 10; i++)
            {
                tableIds[i] = newTable[i]._id;
            }

            for (int i = 0; i < 10; i++)
            {
                tableIds1[i] = newTable1[i]._id;
            }

            string[] tableClear = new string[0];
            if (selected == 1)
            {

                if (newTable1[0].employee_id == "5e96358aa7e308000416cf0b")
                {
                    sent = await SendUserToTable.SendUserRequest(tableClear, "5e96358aa7e308000416cf0b");
                    sent = await SendUserToTable.SendUserRequest(tableIds1, "5e96358aa7e308000416cf0b");
                }
                else
                {
                    sent = await SendUserToTable.SendUserRequest(tableClear, "5e96358aa7e308000416cf0b");

                }
                sent = await SendUserToTable.SendUserRequest(tableClear, empId);
                sent = await SendUserToTable.SendUserRequest(tableIds, empId);

                for (int i = 0; i < 10; i++)
                {
                    if (newTable[i].order_id != null)
                    {
                        var sendIt = SendEmpToOrder.SendEmpRequest(newTable[i].order_id._id, RealmManager.All<Employee>().FirstOrDefault()._id);
                    }
                }
            }
            if (selected == 0)
            {

                if (newTable[0].employee_id == "5e96358aa7e308000416cf0b")
                {
                    sent = await SendUserToTable.SendUserRequest(tableClear, "5e96358aa7e308000416cf0b");
                    sent = await SendUserToTable.SendUserRequest(tableIds, "5e96358aa7e308000416cf0b");
                }
                else
                {
                    sent = await SendUserToTable.SendUserRequest(tableClear, "5e96358aa7e308000416cf0b");

                }
                sent = await SendUserToTable.SendUserRequest(tableClear, empId);
                sent = await SendUserToTable.SendUserRequest(tableIds1, empId);

            }
        }
    }
}
