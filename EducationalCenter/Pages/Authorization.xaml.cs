using EducationalCenter.Entity;
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
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public User GlobalUser { get; set; }
        public User CurrentUser { get; set; }
        public Authorization()
        {
            
            CurrentUser = new User();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.Login != null)
            {
                if (CurrentUser.Password != null)
                {
                    //var AutoUser = ADO.Instance.User.Select(c=> c.Login == CurrentUser.Login && c.Password == CurrentUser.Password);
                    GlobalUser = ADO.Instance.User.Where(c => c.Login == CurrentUser.Login && c.Password == CurrentUser.Password).FirstOrDefault();
                    if (GlobalUser == null)
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                    else
                    {

                        if (GlobalUser.Role.Name == "Администратор")
                        {
                            NavigationService.Navigate(new StartPageAdmin(GlobalUser));
                        }
                        else if (GlobalUser.Role.Name == "Преподователь")
                        {
                            NavigationService.Navigate(new StartPageTicher(GlobalUser));

                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль");

                        }
                    }

                }
                else
                {
                    MessageBox.Show("Введите пароль");
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
            }
        }
    }
}
