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
       
        //temporary testing for login 
        //string userCheck = "abc";
        //string passCheck = "abc";
        
        public MainPage()
        {
            InitializeComponent();
           
        }
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            
            if (uName.Text == null || pWord.Text == null)
            {
                DisplayAlert("Login Error", "User ID and Password fields must not be blank.", "Ok");
              
            }
            else if(tablePicker.SelectedIndex==-1)
            {
                DisplayAlert("Login Error", "You must choose your tables for this shift.", "Ok");

            }
            else
            {
                //if(pull username from DB; and check password match else)
                //DisplayAlert("Login Error", "The username and password combination does not match", "Ok");



                EmpUser currentUser = new EmpUser
                {
                   UserName = uName.Text,
                   Password = pWord.Text,
                 };
                RealmManager.AddOrUpdate<EmpUser>(currentUser);
                var validSendGetTableRequest = GetTableRequest.SendGetTableRequest();
                if(tablePicker.SelectedIndex == 0)
                {
                    //UPDATE DB with user for tables 1-10
                    //GET tables from DB with user == this user
                }
                else
                {
                    //UPDATE DB with user for tables 11-20
                    //GET tables from DB with user == this user
                }
                Navigation.PushAsync(new alertPage());
            }

            //login checking removed for now for easier navigation

            /*if (userID == userCheck && userPassword == passCheck)
            {
                
                
                Navigation.PushAsync(new alertPage());
            }
            else
            {
                DisplayAlert("Not Logged In", "Boo", "Ok");

            }*/

        }
    }
}
