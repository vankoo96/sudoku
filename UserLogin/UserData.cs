using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    static public class UserData
    {
        static public List<User> TestUser
        {
            get
            {
                ResetTestUserData();
                return _testUserList; 
            }
            set { }
        }

        static private List<User> _testUserList = new List<User>(3);

        static private void ResetTestUserData()
        {
            _testUserList.Add(
                new User()
                {
                    username = "admin",
                    password = "admin",
                    fNumber = 121215150,
                    role = 1, /* admin */
                    Created = DateTime.Now,
                    Expire = DateTime.MaxValue
                }
            );


            _testUserList.Add(
                new User()
                {
                    username = "ivan",
                    password = "markov",
                    fNumber = 121215145,
                    role = 4, /* student */
                    Created = DateTime.Now,
                    Expire = DateTime.MaxValue
                }
            );

            _testUserList.Add(
                new User()
                {
                    username = "inspector",
                    password = "parola",
                    fNumber = 121212122,
                    role = 2, /* inspector */
                    Created = DateTime.Now,
                    Expire = DateTime.MaxValue
                }
            );

            /*
            foreach (User u in _testUserList)
            {
                Console.WriteLine(u.username + " " + u.role);
            }
            Console.ReadKey();
            */
        }

        static public User IsUserPassCorrect(string user, string pass)
        {
            List<User> loggedUsers = (from usr in TestUser where usr.username == user && usr.password == pass select usr).ToList();
            if(loggedUsers.Count > 0)
            {
                return loggedUsers.First();
            }
            /*
            foreach (User e in TestUser)
            {
                if (user.Equals(e.username) && pass.Equals(e.password))
                {
                    return e;
                }
            }
            */
            return null;
        }


        static public void AssignUserRole(int index, UserRoles ur)
        {
            foreach (User e in _testUserList)
            {
                if (index == _testUserList.IndexOf(e))
                {
                    e.role = (int)ur;
                    Logger.LogActivity("Промяна на роля на " + e.username);
                }
            }
        }

        static public void SetUserActiveTo(int index, DateTime dt)
        {
            foreach (User e in _testUserList)
            {
                if (index == _testUserList.IndexOf(e))
                {
                    e.Expire = dt;
                    Logger.LogActivity("Промяна на активност на " + e.username);
                }
            }
        }

        static public Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            for (int i = 0; i<_testUserList.Count; i++)
            {
                result.Add(_testUserList[i].username, i);
            }

            return result;
        }
    }
}
