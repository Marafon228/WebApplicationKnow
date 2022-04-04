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
    /// Interaction logic for ViewEvaluation.xaml
    /// </summary>
    public partial class ViewEvaluation : Page
    {
        public User GlobalUser { get; set; }
        public ObservableCollection<Group> ListGroup { get; set; }
        public ObservableCollection<EvaluationAndUser> CurrentEvaluation { get; set; }
        public ViewEvaluation(User user)
        {
            GlobalUser = user;
            ListGroup = new ObservableCollection<Group>(ADO.Instance.Group);
            CurrentEvaluation = new ObservableCollection<EvaluationAndUser>(ADO.Instance.EvaluationAndUser);
            InitializeComponent();

            UpdateGroup();
        }
        private void UpdateGroup()
        {
            ///!!!!
            var SubjectTicer = GlobalUser.UserAndSubject.Select(u => u.Subject).FirstOrDefault();
            var crrr = CBGoup.SelectedValue as Group;
            if (crrr == null)
            {
                crrr = ADO.Instance.Group.FirstOrDefault();
            }
            DGStudt.ItemsSource = ADO.Instance.EvaluationAndUser.Where(u => u.User.Group.Name == crrr.Name).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateGroup();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEvaluationAndStudent(GlobalUser));
        }
    }
}
