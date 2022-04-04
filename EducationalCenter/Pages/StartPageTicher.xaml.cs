using EducationalCenter.Entity;
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
    /// Interaction logic for StartPageTicher.xaml
    /// </summary>
    public partial class StartPageTicher : Page
    {
        public User GlobalUser { get; set; }
        public StartPageTicher(User user)
        {
            GlobalUser = user;
            InitializeComponent();
            MainFrame.Navigate(new ViewGroupAndUsers());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ViewEvaluation(GlobalUser));

        }

        private void Btn_View_Group(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ViewGroupAndUsers());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
