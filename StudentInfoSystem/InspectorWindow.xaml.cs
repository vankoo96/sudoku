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
using System.Windows.Shapes;
using StudentRepository;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for InspectorWindow.xaml
    /// </summary>
    public partial class InspectorWindow : Window
    {
        public InspectorWindow()
        {
            InitializeComponent();
            foreach(Student st in StudentData.ConstantStudents)
            {
                ListBoxItem temp = new ListBoxItem();
                temp.Content = st.group;
                groupListBox.Items.Add(temp);
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            studentListBox.Items.Clear();
            foreach (Student st in StudentData.ConstantStudents)
            {
                if((groupListBox.SelectedItem as ListBoxItem).Content.ToString() == st.group.ToString())
                {
                
                    ListBoxItem tempSt = new ListBoxItem();
                    tempSt.Content = st.firstName + " " + st.lastName;
                    studentListBox.Items.Add(tempSt);
                    
                }
            }

        }

    }
    }
