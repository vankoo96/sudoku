using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentRepository
{
    public class StudentValidation
    {
        public static Student GetStudentDataByUser(User u)
        {
            if(u.fNumber == 0 || StudentData.GetStudent(u.fNumber) == null)
            {
                Console.WriteLine("Не е открит такъв студент.");
                return null;
            } 
            return StudentData.GetStudent(u.fNumber);
        }
    }
}
