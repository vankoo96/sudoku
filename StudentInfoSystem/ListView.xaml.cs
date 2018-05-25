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
using UserLogin;
using StudentRepository;
using System.Collections.ObjectModel;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {

        public ObservableCollection<Student> students { get; set; }

        public ListWindow()
        {

            
            students = new ObservableCollection<Student>();
            InitializeComponent();
            DataContext = this;
            FillList(StudentData.getAllStudents());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (groupField.Text == "")
            {
                FillList(StudentData.getAllStudents());
            }
            else
            {
                int group;
                Int32.TryParse(groupField.Text, out group);
                FillList(StudentData.getStudentsFromGroup(group));
            }
        }

        private void FillList(List<Student> list)
        {
            students.Clear();
            for (int i = 0; i < list.Count; i++)
            {
               students.Add(list.ElementAt(i));
            }
        }
    }
}
