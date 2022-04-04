using EducationalCenter.Entity;
using EducationalCenter.Pages.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EducationalCenter.Pages.Model
{
    /// <summary>
    /// Interaction logic for AddPrep.xaml
    /// </summary>
    public partial class AddPrep : Page
    {
        public ObservableCollection<Subject> ListSubject { get; set; }

        private User currentUser;

        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }


        public AddPrep(User user)
        {

            if (user != null)
            {
                CurrentUser = user;
            }
            else
            {
                CurrentUser = new User();
            }
            ListSubject = new ObservableCollection<Subject>(ADO.Instance.Subject);
            InitializeComponent();
            
        }

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            var subject = CBSubject.SelectedValue as Subject;
            try
            {
                if (CurrentUser.Id == 0)
                {
                    CurrentUser.Role = ADO.Instance.Role.FirstOrDefault(r=> r.Name == "Преподователь");
                    ADO.Instance.User.Add(CurrentUser);
                    ADO.Instance.SaveChanges();
                    ADO.Instance.UserAndSubject.Add(new UserAndSubject() { Subject = subject, User = CurrentUser });
                    ADO.Instance.SaveChanges();
                }
                else
                {
                    ADO.Instance.SaveChanges();
                }
                MessageBox.Show("Данные сохранены !");
                NavigationService.Navigate(new ViewPrep());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
        }
        private void Btn_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewPrep());
        }
    }
}
