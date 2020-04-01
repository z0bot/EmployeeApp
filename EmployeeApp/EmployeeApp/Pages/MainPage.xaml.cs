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
            
            if (uName.Text == null || pWord.Text == null)
            {
                DisplayAlert("Login Error", "User ID and Password fields must not be blank", "Ok");
              
            }
            else
            {
                User currentUser = new User
                {
                   UserName = uName.Text,
                    Password = pWord.Text,
                 };
                RealmManager.AddOrUpdate<User>(currentUser);
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
