using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class UserRolesUtils
    {
        static private Dictionary<UserRoles, string> _RolesDescription = new Dictionary<UserRoles, string>();

        static public Dictionary<UserRoles, string> RolesDescription
        {
            get
            {
                FillRolesDescription();
                return _RolesDescription;
            }
            private set { }
        }

        static private void FillRolesDescription()
        {
            _RolesDescription.Add(UserRoles.ADMIN, "Администаторът има пълни права над платформата.");
            _RolesDescription.Add(UserRoles.ANONYMOUS, "Аномните потребители нямат права.");
            _RolesDescription.Add(UserRoles.INSPECTOR, "Инспекторите имат модераторски права.");
            _RolesDescription.Add(UserRoles.PROFESSOR, "Професторите могат да преглеждат и нанасят оценки.");
            _RolesDescription.Add(UserRoles.STUDENT, "Студентите могат да преглеждат информация и да нанасят оценки");
        }
    }
}
