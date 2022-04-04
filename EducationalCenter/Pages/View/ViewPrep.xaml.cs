using EducationalCenter.Entity;
using EducationalCenter.Pages.Model;
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

namespace EducationalCenter.Pages.View
{
    /// <summary>
    /// Interaction logic for ViewPrep.xaml
    /// </summary>
    public partial class ViewPrep : Page
    {


        /*public ObservableCollection<User> CurrentUserPrep
        {
            get { return (ObservableCollection<User>)GetValue(CurrentUserPrepProperty); }
            set { SetValue(CurrentUserPrepProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentUserPrep.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentUserPrepProperty =
            DependencyProperty.Register("CurrentUserPrep", typeof(ObservableCollection<User>), typeof(ViewPrep), new PropertyMetadata(0));
*/


        private ObservableCollection<User> currentUserPrep;

        public ObservableCollection<User> CurrentUserPrep
        {
            get { return currentUserPrep; }
            set { currentUserPrep = value; }
        }


        public ViewPrep()
        {
            CurrentUserPrep = new ObservableCollection<User>(ADO.Instance.User.Where(u=> u.Role.Name == "Преподователь").ToList());

            InitializeComponent();

            UpdatePage();
        }

        private void Btn_Delete(object sender, RoutedEventArgs e)
        {
            //var prepRemove = DGPrep.SelectedItems.Cast<User>().ToList();
            var prepRemove = DGPrep.SelectedValue as User;
            var sen = (sender as Button).DataContext as User;
            if (MessageBox.Show($"Вы точно хотите удалить {prepRemove.FIO} ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    //var userSt = prepRemove.Select(p=> p.UserAndSubject).ToList();
                    //????????

                    if (prepRemove.UserAndSubject.FirstOrDefault() != null)
                    {

                        ADO.Instance.UserAndSubject.Remove(prepRemove.UserAndSubject.FirstOrDefault());
                        ADO.Instance.SaveChanges();
                    }

                    ADO.Instance.User.Remove(prepRemove);
                                      
                    ADO.Instance.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    UpdatePage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }

        private void Btn_Edit_Prep(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPrep((sender as Button).DataContext as User));
        }

        private void Btn_Add_Prep(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AddPrep(null));
        }

        private void UpdatePage()
        {
            DGPrep.ItemsSource = ADO.Instance.User.Where(u=> u.Role.Name == "Преподователь").ToList();
        }
    }
}
