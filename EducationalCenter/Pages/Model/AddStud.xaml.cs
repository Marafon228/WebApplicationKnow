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
    /// Interaction logic for AddStud.xaml
    /// </summary>
    public partial class AddStud : Page
    {
        public ObservableCollection<Group> ComboGroup { get; set; }

        private User currentUser;

        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        public AddStud(User user)
        {
            if (user != null)
            {
                CurrentUser = user;
            }
            else
            {
                CurrentUser = new User();
            }
            ComboGroup = new ObservableCollection<Group>(ADO.Instance.Group.ToList());
            InitializeComponent();
        }

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentUser.Id == 0)
                {
                    CurrentUser.Group = CBSubject.SelectedValue as Group;
                    CurrentUser.Role = ADO.Instance.Role.FirstOrDefault(r => r.Name == "Ученик");
                    ADO.Instance.User.Add(CurrentUser);
                    ADO.Instance.SaveChanges();
                    
                }
                else
                {
                    ADO.Instance.SaveChanges();
                }
                MessageBox.Show("Данные сохранены !");
                NavigationService.Navigate(new ViewStud());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
        }

        private void Btn_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewStud());

        }
    }
}
