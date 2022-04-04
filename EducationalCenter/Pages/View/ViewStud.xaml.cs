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
    /// Interaction logic for ViewStud.xaml
    /// </summary>
    public partial class ViewStud : Page
    {
        public ObservableCollection<User> CurrentUserStud { get; set; }

        public ViewStud()
        {
            CurrentUserStud = new ObservableCollection<User>(ADO.Instance.User.Where(u => u.Role.Name == "Ученик").ToList());

            InitializeComponent();

            UpdatePage();

        }


        

        private void Btn_Add_Stud(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStud(null));

        }

        private void Btn_Delete(object sender, RoutedEventArgs e)
        {
            var studRemove = DGPrep.SelectedValue as User;
            var sen = (sender as Button).DataContext as User;
            if (MessageBox.Show($"Вы точно хотите удалить {studRemove.FIO} ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    //var userSt = prepRemove.Select(p=> p.UserAndSubject).ToList();
                    //????????

                    if (studRemove.EvaluationAndUser.FirstOrDefault() != null)
                    {

                        ADO.Instance.EvaluationAndUser.Remove(studRemove.EvaluationAndUser.FirstOrDefault());
                        ADO.Instance.SaveChanges();
                    }

                    ADO.Instance.User.Remove(studRemove);

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

        private void Btn_Edit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStud((sender as Button).DataContext as User));

        }


        private void UpdatePage()
        {
            DGPrep.ItemsSource = ADO.Instance.User.Where(u => u.Role.Name == "Ученик").ToList();
        }


    }
}
