using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    public class LoginValidation
    {
        private string username;
        private string password;
        private string errorMessage;
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError _errorField; // tova da se promeni kato preimenuva proekta 

        public LoginValidation(string user, string pass, ActionOnError a)
        {
            this.username = user;
            this.password = pass;
            this._errorField = a;
        }

        public bool ValidateUserInput(ref User u)
        {   

            Boolean emptyUserName;
            emptyUserName = username.Equals(String.Empty);
            if (emptyUserName == true)
            { 
                errorMessage = "Не е посочено потребителско име";
                _errorField(errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                errorMessage = "Не е посочена парола";
                _errorField(errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if(username.Length < 5)
            {
                errorMessage = "Въведеното потребителско име е под 5 символа";
                _errorField(errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (password.Length < 5)
            {
                errorMessage = "Въведената парола е под 5 символа";
                _errorField(errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            u = UserData.IsUserPassCorrect(username, password);

            if(u == null)
            {
                errorMessage = "Не е открит такъв потребител";
                _errorField(errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            currentUserRole = (UserRoles)u.role;
            currentUserUsername = u.username;
     
            Logger.LogActivity("Успешен Login");
            return true;
        }

        static public UserRoles currentUserRole
        {
            get;
            private set;
        }

        static public string currentUserUsername
        {
            get;
            private set;
        }
    }
}
