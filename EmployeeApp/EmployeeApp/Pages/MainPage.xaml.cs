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
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
           
        }
        public async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            
            if (uName.Text == null || pWord.Text == null || tableSelector.SelectedIndex==-1)
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
            var tryit = await GetTableRequest.SendGetTableRequest();
            if (selected == 1)
            {
                newTable = RealmManager.All<TableList>().FirstOrDefault().tables.Where<Table>((Table m) => m.table_number > 10).ToList();

            }
            else
            {
                newTable = RealmManager.All<TableList>().FirstOrDefault().tables.Where<Table>((Table m) => m.table_number < 11).ToList();


            }

            for(int i=0; i<10; i++)
            {
                var sent = await SendUserToTable.SendUserRequest(newTable[i]._id, empId);
            }
        }
    }
}
