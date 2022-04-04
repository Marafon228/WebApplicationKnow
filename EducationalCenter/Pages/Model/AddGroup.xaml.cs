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
    /// Interaction logic for AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Page
    {
        public Group MyGroup { get; set; }
        public AddGroup(Group group )
        {
            if (group != null)
            {
                MyGroup = group;
            }
            else
            {
                MyGroup = new Group();
            }

            InitializeComponent();
        }

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyGroup.Id == 0)
                {
                    ADO.Instance.Group.Add(MyGroup);
                    ADO.Instance.SaveChanges();

                }
                else
                {
                    ADO.Instance.SaveChanges();
                }
                MessageBox.Show("Сохранено!");
                NavigationService.Navigate(new ViewGroup());


            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }

        }

        private void Btn_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewGroup());
        }
    }
}
