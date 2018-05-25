using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public class Student
    {
        public string firstName;
        public string secondName;
        public string lastName;
        public string faculty;
        public string speciality;
        public string learningLevel;
        public string status;
        public int facultyNumber;
        public DateTime lastInvolved;
        public int course;
        public int division;
        public int group;

        public override string ToString()
        {
            return firstName;
        }
    }
}
