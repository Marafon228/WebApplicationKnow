using EducationalCenter.Entity;
using EducationalCenter.Pages.View;
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

namespace EducationalCenter.Pages.Model
{
    /// <summary>
    /// Interaction logic for AddPredmet.xaml
    /// </summary>
    public partial class AddPredmet : Page
    {
        private Subject cuurentSubject;

        public Subject CuurentSubject
        {
            get { return cuurentSubject; }
            set { cuurentSubject = value; }
        }

        public AddPredmet(Subject subject)
        {

            if (subject != null)
            {
                CuurentSubject = subject;
            }
            else
            {
                CuurentSubject = new Subject();
            }

            InitializeComponent();
        }

        private void Btn_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CuurentSubject.Id == 0)
                {
                    ADO.Instance.Subject.Add(CuurentSubject);
                    ADO.Instance.SaveChanges();
                }
                else
                {
                    ADO.Instance.SaveChanges();
                }
                MessageBox.Show("Сохранено!");
                NavigationService.Navigate(new ViewPredmet());

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
