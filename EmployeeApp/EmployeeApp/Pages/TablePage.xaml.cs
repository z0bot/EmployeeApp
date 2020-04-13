using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EmployeeApp.Models.ServiceRequests;
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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var myList = new List<Table>(); //your list here
            int checker =1;
            
            
            TableButts.Children.Clear(); //just in case so you can call this code several times np..
            
                var newTable = new List<Table>();
                var tryit = await GetTableRequest.SendGetTableRequest();
            if (MyGlobals.MySection == 1)
            {
                newTable = RealmManager.All<TableList>().FirstOrDefault().tables.Where<Table>((Table m) => m.table_number > 10).ToList();
                
            }
            else
            {
                newTable = RealmManager.All<TableList>().FirstOrDefault().tables.Where<Table>((Table m) => m.table_number < 11).ToList();


            }
            for (int i = 0; i < 10; i++)
            {
                var btn = new Button()
                {
                    Text = newTable[i].tableNumberString,
                    Margin = 0,
                    WidthRequest = 250,
                    HeightRequest = 75,
                    TextColor = Color.White,
                    FontSize = 30,
                };
                if (newTable[i].order_id == null)
                {
                    btn.BackgroundColor = Color.Gray;
                }
                else
                {
                    btn.BackgroundColor = Color.FromHex("#24BF87");
                }
                int tblNum = newTable[i].table_number;
                btn.Clicked += delegate (object sender, EventArgs e) { OnTableClicked(sender, e, tblNum); };
                TableButts.Children.Add(btn);
            }
          

            
            
        }
        async private void OnTableClicked(object sender, EventArgs e, int tblNum)
        {
            //do you stuff upon is
            var getTable = await GetTableRequest.SendGetTableRequest(tblNum);
            await Navigation.PushAsync(new YourOrderPage());

        }


        async void LogOut_Clicked(System.Object sender, System.EventArgs e)
        {
          bool result1 = await DisplayAlert("Log Out?","Are you sure you want to log out?", "Yes", "No");
            if (result1 == true)
               await Navigation.PushAsync(new MainPage());
            else
                return;
            
        }
      
    }
}
