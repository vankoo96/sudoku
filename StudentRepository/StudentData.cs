using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentRepository
{
    static public class StudentData
    {
        static private List<Student> _ConstantStudents = new List<Student>() {

            new Student()
            {
                firstName = "Nikola",
                secondName = "Stoqnov",
                lastName = "Kunin",
                faculty = "FKSU",
                speciality = "KSI",
                learningLevel = "Bakalavur",
                status = "Zaveril",
                facultyNumber = 121215145,
                lastInvolved = Convert.ToDateTime("01/02/2018"),
                course = 3,
                division = 1,
                group = 39
            }, new Student()
            {
                    firstName = "Mitko",
                    secondName = "Ivanov",
                    lastName = "Dimitrov",
                    faculty = "FKSU",
                    speciality = "KSI",
                    learningLevel = "Bakalavur",
                    status = "Заверил",
                    facultyNumber = 121215149,
                    lastInvolved = Convert.ToDateTime("01/04/2018"),
                    course = 2,
                    division = 1,
                    group = 38
            },new Student()
                {
                    firstName = "Ivan",
                    secondName = "Ivanov",
                    lastName = "Ivanov",
                    faculty = "FKSU",
                    speciality = "KSI",
                    learningLevel = "Bakalavur",
                    status = "Заверил",
                    facultyNumber = 121215147,
                    lastInvolved = Convert.ToDateTime("01/02/2018"),
                    course = 2,
                    division = 1,
                    group = 40
                }

        };

        static public List<Student> ConstantStudents
        {
            get
            {
                _ConstantStudents.Clear();
                FillConstantStudents();
                return _ConstantStudents;
            }
            private set { }
        }

        public static List<Student> getAllStudents()
        {
            return _ConstantStudents;
        }

        public static List<Student> getStudentsFromGroup(int group)
        {
            List<Student> result = new List<Student>();
            for(int i=0; i < _ConstantStudents.Count; i++)
            {
                if (_ConstantStudents.ElementAt(i).group == group)
                {
                    result.Add(_ConstantStudents.ElementAt(i));
                }
            }
            return result;
        }






        static private void FillConstantStudents()
        {
            _ConstantStudents.Add(new Student()
            {
                firstName = "Nikola",
                secondName = "Stoqnov",
                lastName = "Kunin",
                faculty = "FKSU",
                speciality = "KSI",
                learningLevel = "Bakalavur",
                status = "Zaveril",
                facultyNumber = 121215145,
                lastInvolved = Convert.ToDateTime("01/02/2018"),
                course = 3,
                division = 1,
                group = 39
                }
            );

            _ConstantStudents.Add(new Student()
                {
                    firstName = "Ivan",
                    secondName = "Ivanov",
                    lastName = "Ivanov",
                    faculty = "FKSU",
                    speciality = "KSI",
                    learningLevel = "Bakalavur",
                    status = "Заверил",
                    facultyNumber = 121215147,
                    lastInvolved = Convert.ToDateTime("01/02/2018"),
                    course = 2,
                    division = 1,
                    group = 40
                }
            );

            _ConstantStudents.Add(new Student()
                {
                    firstName = "Mitko",
                    secondName = "Ivanov",
                    lastName = "Dimitrov",
                    faculty = "FKSU",
                    speciality = "KSI",
                    learningLevel = "Bakalavur",
                    status = "Заверил",
                    facultyNumber = 121215149,
                    lastInvolved = Convert.ToDateTime("01/04/2018"),
                    course = 2,
                    division = 1,
                    group = 38
                }
            );

            
        }

        static public Student GetStudent(int facNumber)
        {
            if(facNumber.ToString().Length == 9)
            {
                List<Student> studentFound = (from student in ConstantStudents where student.facultyNumber == facNumber select student).ToList();
                if (studentFound.Count > 0)
                {
                    return studentFound.First();
                }
            }
            return null;
        }

        static public string PrepareCertificate(int fN)
        {
            Student s = GetStudent(fN);
            if(s!=null)
            {
                if(s.status=="Zaveril")
                {
                    string cert = "Уверение, че студентът " + s.firstName + " " + s.secondName + " " + s.lastName + " с факултетен номер: " + s.facultyNumber + " е със статус: " + s.status;
                    return cert;
                } else
                {
                    Console.WriteLine("Студентът не е заверил");
                    return null;
                }
            } else
            {
                Console.WriteLine("Няма студент с посочения факултетен номер.");
                return null;
            }
        }

        static public void WriteCertificate(string c, string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
                File.WriteAllText(fileLocation, c + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(fileLocation, c + Environment.NewLine);
            }
        }
    }
}
