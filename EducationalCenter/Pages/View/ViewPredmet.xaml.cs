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
    /// Interaction logic for ViewPredmet.xaml
    /// </summary>
    public partial class ViewPredmet : Page
    {
        public ObservableCollection<Subject> MySubject { get; set; }

        public ViewPredmet()
        {
            MySubject = new ObservableCollection<Subject>(ADO.Instance.Subject);
            InitializeComponent();
            UpdatePage();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPredmet(null));
        }

        private void Btn_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                ADO.Instance.Subject.Remove(DGSubject.SelectedValue as Subject);
                ADO.Instance.SaveChanges();
                MessageBox.Show("Успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);

            }
            UpdatePage();
        }

        private void sdrfwsedfsdezfe(object sender, RoutedEventArgs e)
        {

            var navig = DGSubject.SelectedValue as Subject;
            NavigationService.Navigate(new AddPredmet(navig));


        }
        private void UpdatePage()
        {
            DGSubject.ItemsSource = ADO.Instance.Subject.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var sad = (sender as Button).DataContext as Subject;
            var navig = DGSubject.SelectedValue as Subject;
            NavigationService.Navigate(new AddPredmet(navig));
        }
    }
}
