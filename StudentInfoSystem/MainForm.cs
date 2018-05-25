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
using StudentRepository;

namespace StudentInfoSystem
{
    public partial class MainWindow : Window
    {
        public void clearAllControls()
        {
            foreach (var item in studentGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
            }

            foreach (var item in personalGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
            }

            foreach (var item in studentInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
            }
        }

        public void fillStudentControls(Student s)
        {
            ((TextBox)tb_fName).Text = s.firstName;
            ((TextBox)tb_sName).Text = s.secondName;
            ((TextBox)tb_lName).Text = s.lastName;

            ((TextBox)tb_faculty).Text = s.faculty;
            ((TextBox)tb_speciality).Text = s.speciality;
            ((TextBox)tb_oks).Text = s.learningLevel;
            ((TextBox)tb_status).Text = s.status;
            ((TextBox)tb_fNumber).Text = s.facultyNumber.ToString();

            ((TextBox)tb_course).Text = s.course.ToString();
            ((TextBox)tb_division).Text = s.division.ToString();
            ((TextBox)tb_group).Text = s.group.ToString();
        }

        public void disableAllControls()
        {
            foreach (Control ctrl in studentGrid.Children)
            {
                if(ctrl.Name!="tb_user" && ctrl.Name != "user" && ctrl.Name!="tb_pass" && ctrl.Name!="pass" && ctrl.Name!="btnLogin")
                {
                    ctrl.IsEnabled = false;
                }
            }

            foreach (Control ctrl in personalGrid.Children)
            {
                if (ctrl.Name != "tb_user" && ctrl.Name != "user" && ctrl.Name != "tb_pass" && ctrl.Name != "pass" && ctrl.Name != "btnLogin")
                {
                    ctrl.IsEnabled = false;
                }
            }

            foreach (Control ctrl in studentInfoGrid.Children)
            {
                if (ctrl.Name != "tb_user" && ctrl.Name != "user" && ctrl.Name != "tb_pass" && ctrl.Name != "pass" && ctrl.Name != "btnLogin")
                {
                    ctrl.IsEnabled = false;
                }
            }
        }

        public void enableAllControls()
        {
            foreach (Control ctrl in studentGrid.Children)
            {
                ctrl.IsEnabled = true;
            }

            foreach (Control ctrl in personalGrid.Children)
            {
                ctrl.IsEnabled = true;
            }

            foreach (Control ctrl in studentInfoGrid.Children)
            {
                ctrl.IsEnabled = true;
            }
        }
    }
}
