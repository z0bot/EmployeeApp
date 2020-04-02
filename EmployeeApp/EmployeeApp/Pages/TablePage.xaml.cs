using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EmployeeApp.Models;


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
        public void DisplayOrder()
        {
            uxtableView.ItemsSource = RealmManager.All<TableList>().FirstOrDefault().tables;
        }

    }
}
