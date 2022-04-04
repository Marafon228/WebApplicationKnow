using EducationalCenter.Entity;
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
    /// Interaction logic for ViewGroupAndUsers.xaml
    /// </summary>
    public partial class ViewGroupAndUsers : Page
    {
        public ObservableCollection<Group> ListGroup { get; set; }
        public ObservableCollection<User> CurrentUsers { get; set; }
        public ViewGroupAndUsers()
        {
            ListGroup = new ObservableCollection<Group>(ADO.Instance.Group);
            InitializeComponent();

            UpdateGrid();
        }
        private void UpdateGrid()
        {
            var cr = ListGroup.Select(c => c.Name);
            var crrr = CBGoup.SelectedValue as Group;
            if (crrr == null)
            {
                crrr = ADO.Instance.Group.FirstOrDefault();
            }
            var curretnGroup = ListGroup.FirstOrDefault().Name;
            DGPrep.ItemsSource = ADO.Instance.User.Where(u => u.Group.Name == crrr.Name).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();

        }
    }
}
