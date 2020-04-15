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
           // var myList = new List<Table>(); //your list here
            
            
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
                btn.Clicked += OnTableClicked;
                //btn.Clicked += delegate (object sender, EventArgs e) { OnTableClicked(sender, e, tblNum); };
                TableButts.Children.Add(btn);
            }
          

            
            
        }
        async private void OnTableClicked(object sender, EventArgs e)
        {
            Button tableNum = (Button)sender;
            string[] tabNum = tableNum.Text.Split();
            int tblNum = Convert.ToInt32(tabNum[1]);
            //do you stuff upon is
            MyGlobals.workingTable = tblNum;
            var getTable = await GetTableRequest.SendGetTableRequest(tblNum);
            await Navigation.PushAsync(new YourOrderPage());

        }


        async void LogOut_Clicked(System.Object sender, System.EventArgs e)
        {
            bool result1 = await DisplayAlert("Log Out?", "Are you sure you want to log out?", "Yes", "No");
            if (result1 == true)
            {
                var myList = new List<Table>();
                myList = RealmManager.All<TableList>().FirstOrDefault().tables.ToList();
                for (int i = 0; i < 10; i++)
                {
                    var sent = await SendUserToTable.SendUserRequest(myList[i]._id, "5e96358aa7e308000416cf0b");
                }
                await Navigation.PushAsync(new MainPage());
            }
            else
                return;

        }

    }
}
