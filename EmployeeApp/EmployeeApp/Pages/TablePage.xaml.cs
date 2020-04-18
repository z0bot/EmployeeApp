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
            
            
            TableButts.Children.Clear(); 
            
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
                    HeightRequest = 85,
                    TextColor = Color.White,
                    FontSize = 29,
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
                string[] tableIds = new string[10];
                for (int i = 0; i < 10; i++)
                {
                    tableIds[i] = myList[i]._id;
                }

                var newTable = new List<Table>();
                var newTable1 = new List<Table>();
                var tryit = await GetTableRequest.SendGetTableRequest();

                newTable = RealmManager.All<TableList>().FirstOrDefault().tables.Where<Table>((Table m) => m.table_number > 10).ToList();
                newTable1 = RealmManager.All<TableList>().FirstOrDefault().tables.Where<Table>((Table m) => m.table_number < 11).ToList();
                string[] tableClear = new string[0];
                if (MyGlobals.MySection == 0)
                {
                    if (newTable[0].employee_id == "5e96358aa7e308000416cf0b")
                    {
                        string[] krystalTables = new string[20];
                        for (int i = 0; i < 10; i++)
                        {
                            krystalTables[i] = newTable1[i]._id;
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            krystalTables[i + 10] = newTable[i]._id;
                        }
                        var sent2 = await SendUserToTable.SendUserRequest(tableClear, RealmManager.All<Employee>().FirstOrDefault()._id);
                        var sent = await SendUserToTable.SendUserRequest(krystalTables, "5e96358aa7e308000416cf0b");
                    }
                    else
                    {
                        var sent2 = await SendUserToTable.SendUserRequest(tableClear, RealmManager.All<Employee>().FirstOrDefault()._id);
                        var sent = await SendUserToTable.SendUserRequest(tableIds, "5e96358aa7e308000416cf0b");

                    }

                }
                else
                {
                    if (newTable1[0].employee_id == "5e96358aa7e308000416cf0b")
                    {
                        string[] krystalTables = new string[20];
                        for (int i = 0; i < 10; i++)
                        {
                            krystalTables[i] = newTable1[i]._id;
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            krystalTables[i + 10] = newTable[i]._id;
                        }
                        var sent2 = await SendUserToTable.SendUserRequest(tableClear, RealmManager.All<Employee>().FirstOrDefault()._id);
                        var sent = await SendUserToTable.SendUserRequest(krystalTables, "5e96358aa7e308000416cf0b");
                    }
                    else
                    {
                        var sent2 = await SendUserToTable.SendUserRequest(tableClear, RealmManager.All<Employee>().FirstOrDefault()._id);
                        var sent = await SendUserToTable.SendUserRequest(tableIds, "5e96358aa7e308000416cf0b");

                    }
                }



                await Navigation.PushAsync(new MainPage());
            }
            else
                return;

        }

    }
}
