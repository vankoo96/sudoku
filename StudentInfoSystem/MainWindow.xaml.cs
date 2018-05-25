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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            disableAllControls();
        }

        //static bool isLoggedIn = false;
        static UserRoles currentUserRole = UserRoles.ANONYMOUS;

        private void buttonLogin(object sender, RoutedEventArgs e)
        {

            if(currentUserRole == UserRoles.ANONYMOUS)
            {
                User u = UserData.IsUserPassCorrect(((TextBox)tb_user).Text, ((TextBox)tb_pass).Text);

                if (u != null)
                {
                    //isLoggedIn = true;
                    enableAllControls();
                    
                    user.IsEnabled = false;
                    tb_user.IsEnabled = false;
                    tb_pass.Text = String.Empty;
                    pass.IsEnabled = false;
                    tb_pass.IsEnabled = false;
                    
                    btnLogin.Content = "Изход";
                    currentUserRole = (UserRoles)u.role;
                    switch (u.role)
                    {
                        case (int)UserRoles.STUDENT:
                            Student s = StudentValidation.GetStudentDataByUser(u);
                            fillStudentControls(s);
                            break;
                        case (int)UserRoles.ADMIN:
                            btnGrades.Visibility = Visibility.Visible;
                            fNumberProfessor.Visibility = Visibility.Visible;
                            tb_fNumberProfessor.Visibility = Visibility.Visible;
                            buttonSearchStudent.Visibility = Visibility.Visible;
                            /* u.role = (int)UserRoles.ANONYMOUS; */
                            break;
                        case (int)UserRoles.INSPECTOR:
                            InspectorWindow iw = new InspectorWindow();
                            iw.Show();
                            //this.Close();
                            break;
                        default: break;
                    }

                    GradeWindow gradeWindow = new GradeWindow();
                    gradeWindow.Show();
                        
 


                }
            } else
            {
                
                currentUserRole = UserRoles.ANONYMOUS;

                user.IsEnabled = true;
                tb_user.IsEnabled = true;
                pass.IsEnabled = true;
                tb_pass.IsEnabled = true;

                btnLogin.Content = "Вход";
                //isLoggedIn = false;
                clearAllControls();
                disableAllControls();

                btnGrades.Visibility = Visibility.Hidden;
                fNumberProfessor.Visibility = Visibility.Hidden;
                tb_fNumberProfessor.Visibility = Visibility.Hidden;
                buttonSearchStudent.Visibility = Visibility.Hidden;
            }
            
        }

        private void buttonSearchStudent_Click(object sender, RoutedEventArgs e)
        {
            Student s = StudentData.GetStudent((int.Parse(tb_fNumberProfessor.Text)));
            if(s!=null)
            {
                fillStudentControls(s);
            }
        }
    }
}
