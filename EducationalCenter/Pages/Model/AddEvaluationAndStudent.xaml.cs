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

namespace EducationalCenter.Pages.Model
{
    /// <summary>
    /// Interaction logic for AddEvaluationAndStudent.xaml
    /// </summary>
    public partial class AddEvaluationAndStudent : Page
    {
        public User GlobalUser { get; set; }
        public EvaluationAndUser CurrentEvaluation { get; set; }
        public ObservableCollection<User> ListStudent { get; set; }
        public AddEvaluationAndStudent(User user)
        {
            CurrentEvaluation = new EvaluationAndUser();
            ListStudent = new ObservableCollection<User>(ADO.Instance.User.Where(u=> u.Role.Name == "Ученик").ToList());
            GlobalUser = user;
            InitializeComponent();
        }

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                var SubjectTicer = GlobalUser.UserAndSubject.Select(u => u.Subject).FirstOrDefault();

                CurrentEvaluation.Subject = SubjectTicer;
                CurrentEvaluation.User = CBStud.SelectedValue as User;
                CurrentEvaluation.Day = ADO.Instance.Day.FirstOrDefault();
                ADO.Instance.EvaluationAndUser.Add(CurrentEvaluation);
                ADO.Instance.SaveChanges();
                MessageBox.Show("Данные сохранены");
                NavigationService.GoBack();




            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
                
            }
        }

        private void Btn_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
