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
    /// Interaction logic for ViewGroup.xaml
    /// </summary>
    public partial class ViewGroup : Page
    {
        public ObservableCollection<Group> MyGroups { get; set; }
        public ViewGroup()
        {
            InitializeComponent();

            UpdatePage();

        }

        private void Btn_Edit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddGroup((sender as Button).DataContext as Group));
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddGroup(null));



        }

        private void Btn_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                ADO.Instance.Group.Remove(DGGroup.SelectedValue as Group);
                ADO.Instance.SaveChanges();
                MessageBox.Show("Группа удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
                
            }
            
            UpdatePage();
        }

        private void UpdatePage()
        {
            DGGroup.ItemsSource = ADO.Instance.Group.ToList();
        }
    }
}
