using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EmployeeApp
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
            //WORKING HERE
        }
    }
}