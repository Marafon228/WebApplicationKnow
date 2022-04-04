using MAbileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAbileApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public User CurrentUser { get; set; }
        public StartPage(User user)
        {
            CurrentUser = user;

            InitializeComponent();

            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EvaluationPage(CurrentUser));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Raspisanie());

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}