using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EmployeeApp.Pages
{
    public partial class alertPage : ContentPage
    {
        public alertPage()
        {
            InitializeComponent();

        }
        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Back Button Error!", "If you want to exit, you must log out.", "Ok");
            return true;
        }
        void Tables_Clicked(System.Object sender, System.EventArgs e)
        {
           
            Navigation.PushAsync(new TablePage());
        }

        async void LogOut_Clicked(System.Object sender, System.EventArgs e)
        {
            bool result1 = await DisplayAlert("Log Out?", "Are you sure you want to log out?", "Yes", "No");
            if (result1 == true)
                await Navigation.PushAsync(new MainPage());
            else
                return;

        }
    }
}