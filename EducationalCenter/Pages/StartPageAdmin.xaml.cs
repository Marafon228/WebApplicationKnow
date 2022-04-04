using EducationalCenter.Entity;
using EducationalCenter.Pages.Model;
using EducationalCenter.Pages.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EducationalCenter.Pages
{
    /// <summary>
    /// Interaction logic for StartPageAdmin.xaml
    /// </summary>
    public partial class StartPageAdmin : Page
    {
        public User GlobalUser { get; set; }
        public StartPageAdmin(User user)
        {
            GlobalUser = user;
            InitializeComponent();

            MainFrame.Navigate(new ViewPrep());
        }

        private void Btn_View_Predmet(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new ViewPredmet());
            MainFrame.Navigate(new ViewPredmet());

        }

        private void Btn_View_Group(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new ViewGroup());
            MainFrame.Navigate(new ViewGroup());

        }

        private void Bnt_View_Stud(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ViewStud());
            //NavigationService.Navigate(new ViewStud());
        }

        private void Btn_View_Prep(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ViewPrep());
            //NavigationService.Navigate(new ViewPrep());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
