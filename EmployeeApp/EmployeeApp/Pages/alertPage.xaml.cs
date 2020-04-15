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
                    HeightRequest = 50,
                    TextColor = Color.White,
                    FontSize = 15,
                    
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