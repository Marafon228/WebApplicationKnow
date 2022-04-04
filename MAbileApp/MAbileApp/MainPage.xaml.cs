using MAbileApp.Model;
using MAbileApp.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MAbileApp
{
    public partial class MainPage : ContentPage
    {
        public User CurrentUser { get; set; }
        public MainPage()
        {
            CurrentUser = new User();
            InitializeComponent();
            BindingContext = this;
        }

        private async void Btn_SignIn(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var result = client.UploadString("http://192.168.0.101:54590/api/Users/SignIn", JsonConvert.SerializeObject(CurrentUser));
            if (result != null)
            {
                var roleUser = JsonConvert.DeserializeObject<User>(result);
                if (roleUser.Role == "Ученик")
                {
                    await DisplayAlert("Сообщение", "Регистрация прошла успешно", "OK");
                    await Navigation.PushAsync(new StartPage(roleUser), true);
                }
                /*else if (roleUser.Role == "Учитель")
                {
                    await DisplayAlert("Message", "Registration was successful", "OK");
                    await Navigation.PushAsync(new StartPageStaff(), true);
                }*/
                else
                {
                    await DisplayAlert("Сообщение", "Невенрный логин или пароль", "OK");
                }
            }
        }
    }
}
