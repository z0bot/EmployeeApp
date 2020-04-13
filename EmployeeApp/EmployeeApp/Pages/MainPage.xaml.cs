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
            
            if (uName.Text == null || pWord.Text == null || tableSelector.SelectedIndex==-1)
            {
                DisplayAlert("Login Error", "User ID, Password fields and Section must not be blank", "Ok");
              
            }
            else
            {
                EmpUser currentUser = new EmpUser
                {
                   UserName = uName.Text,
                    Password = pWord.Text,
                 };

                MyGlobals.MySection = tableSelector.SelectedIndex;
                RealmManager.RemoveAll<EmpUser>();
                RealmManager.RemoveAll<Order>();
                RealmManager.RemoveAll<Table>();
                RealmManager.AddOrUpdate<EmpUser>(currentUser);
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
