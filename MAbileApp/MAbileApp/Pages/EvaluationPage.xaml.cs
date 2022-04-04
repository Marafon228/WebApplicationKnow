using MAbileApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAbileApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EvaluationPage : ContentPage
    {
        public User CurrentUser { get; set; }
        public EvaluationPage(User user)
        {
            CurrentUser = user;
            InitializeComponent();
            var client = new WebClient();
            var response = client.DownloadString("http://192.168.0.101:54590/api/EvaluationAndUsers/GettEvaluationAndUser");
            var res = JsonConvert.DeserializeObject<List<Evaluation>>(response);
            ListViewEvaluation.ItemsSource = res.Where(e => e.IdUser == CurrentUser.Id);
        }
    }
}