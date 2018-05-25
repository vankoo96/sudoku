using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentInfoSystem
{
    public partial class GradeWindow : Window
    {

        public GradeWindow()
        {
            InitializeComponent();
        }

        GradeContext gradeContext = new GradeContext();

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Grade grade = new Grade();
            int value = 0;
            int.TryParse(gradeField.Text,out value);
            grade.value = value;
            gradeContext.grades.Add(grade);
            gradeContext.SaveChanges();
        }
    }
}
