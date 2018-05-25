using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    class Program
    {
        
        static public void errorFunc(string s)
        {
            Console.WriteLine("!!! " + s + " !!!");
            Console.ReadKey();
        }

        static public void adminMenu()
        {
            Console.WriteLine("Изберете опция: \n0: Изход: \n1: Промяна на роля на потребител \n2: Промяна на активност на потребител \n3: Списък с потребителите \n4: Преглед на лог на активност \n5: Преглед на текуща активност \n6: Списък от роли");
            int adminChoice = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, int> allusers = UserData.AllUsersUsernames();
            string userToChange = "";
            switch (adminChoice)
            {
                case 0: break;
                case 1:
                    Console.WriteLine("Въведете потребителско име: ");
                    userToChange = Console.ReadLine();
                    Console.WriteLine("Въведете нова роля на потребителя: ");
                    int newRole = int.Parse(Console.ReadLine());
                    UserData.AssignUserRole(allusers[userToChange], (UserRoles)newRole);
                    break;
                case 2:
                    Console.WriteLine("Въведете потребителско име: ");
                    userToChange = Console.ReadLine();
                    Console.WriteLine("Въведете нова дата за потребителя: ");
                    DateTime newDate = Convert.ToDateTime(Console.ReadLine());
                    UserData.SetUserActiveTo(allusers[userToChange], newDate);
                    break;
                case 3:
                    foreach (KeyValuePair<string, int> item in allusers)
                    {
                        Console.WriteLine(item.Key); 
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    StreamReader sr = new StreamReader("C:/Users/RADIKAL/Downloads/test.txt");
                    StringBuilder sb = new StringBuilder();
                    sb.Append(sr.ReadToEnd());
                    Console.WriteLine(sb.ToString());
                    sr.Close();
                    break;
                case 5: Console.WriteLine("Моля, въведете филтър: ");
                        string f = Console.ReadLine();
                        Logger.GetCurrentSessionActivities(f);
                        break;
                case 6: Console.WriteLine("Описание на потребителите: ");
                        foreach(KeyValuePair<UserRoles, string> item in UserRolesUtils.RolesDescription)
                        {
                            Console.WriteLine(item.Key + " ==> " + item.Value);
                        }
                        break;
                default: break;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Моля, въведете потребителско име:");
            string enteredUsername = Console.ReadLine();
            Console.WriteLine("Моля, въведете парола:");
            string enteredPassword = Console.ReadLine();
            
            LoginValidation lv = new LoginValidation(enteredUsername, enteredPassword, errorFunc);

            User tempUser = new User();

            if(lv.ValidateUserInput(ref tempUser))
            {
                Console.WriteLine("\nПотребителско име: " + tempUser.username);
                Console.WriteLine("Парола: " + tempUser.password);
                Console.WriteLine("Факултетен номер: " + tempUser.fNumber);
                Console.WriteLine("Потребителски тип: " + tempUser.role + "\n");

               switch(LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Потребителят е: Анонимен");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Потребителят е: Администратор");
                        adminMenu();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Потребителят е: Инспектор");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Потребителят е: Професор");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Потребителят е: Студент");
                        break;
                }
            }
        }
    }
}
