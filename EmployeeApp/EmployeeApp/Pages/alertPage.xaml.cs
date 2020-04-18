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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            string id = RealmManager.All<Employee>().FirstOrDefault()._id;
            //Getting notifications for this employee
            var req = await GetNotificationsRequest.SendNotificationRequest(id);

            //Creating alert list  
            AlertButts.Children.Clear();

            var newList = new List<Notifications>();
            newList = RealmManager.All<NotificationList>().FirstOrDefault().notifications.ToList();

            for (int i = 0; i < newList.Count(); i++)
            {
                var btn = new Button()
                {
                    Text = newList[i].sender + " - " + newList[i].notificationType,
                    Margin = 0,
                    WidthRequest = 300,
                    HeightRequest = 60,
                    TextColor = Color.White,
                    FontSize = 12,
                    
                };
                string[] typeNotif = newList[i].sender.Split();
                if (typeNotif[0] == "Table")
                {
                    btn.BackgroundColor = Color.FromHex("#d26868");
                }
                else
                {
                    btn.BackgroundColor = Color.FromHex("#4bc1db");
                }
                // btn.Clicked += OnAlertClicked;
                string notifId = newList[i]._id;
                btn.Clicked += delegate (object sender, EventArgs e) { OnAlertClicked(sender, e, notifId); };
                AlertButts.Children.Add(btn);
            }
        }

        async private void OnAlertClicked(object sender, EventArgs e, string notifId)
        {
             Button alertMessage = (Button)sender;
                //do you stuff upon is
              bool result1 =  await DisplayAlert(alertMessage.Text, "Remove this Notification?", "Remove Notication", "Keep Notification");
            if(result1 == true)
            {
                var weGood = RemoveNotification.SendRemoveNotification(notifId);
               await Navigation.PushAsync(new alertPage());         


            }

        }



        void Tables_Clicked(System.Object sender, System.EventArgs e)
        {
           
            Navigation.PushAsync(new TablePage());
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
                if (MyGlobals.MySection ==0)
                {
                    if(newTable[0].employee_id == "5e96358aa7e308000416cf0b")
                    {
                        string[] krystalTables = new string[20];
                        for(int i=0; i<10; i++)
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
                            krystalTables[i+10] = newTable[i]._id;
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