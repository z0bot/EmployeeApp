using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace EmployeeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        public TablePage()
        {
            InitializeComponent();
        }

        async void LogOut_Clicked(System.Object sender, System.EventArgs e)
        {
          bool result1 = await DisplayAlert("Log Out?","Are you sure you want to log out?", "Yes", "No");
            if (result1 == true)
               await Navigation.PushAsync(new MainPage());
            else
                return;
            
        }
       void Table1Clicked(System.Object sender, System.EventArgs e)
        {
          
        }
        void Table2Clicked(System.Object sender, System.EventArgs e)
        {

        }
    }
}
