using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Common.Security;

namespace Common.Security
{
    public class SecurityManager
    {
        public delegate CustomUser GetUser(String user_name, String password);
        public delegate CustomUser GetUserRol(String user_name, String password, int rol);
        public GetUser GetUserImplementation;
        public GetUserRol GetUserImplementationRol;


        private static SecurityManager instance;

        public static SecurityManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SecurityManager();

                return instance;
            }
            set { instance = value; }
        }


        public bool AuthenticateUser(String user_name, String password)
        {
            CustomUser customUser = GetUserImplementation(user_name, password);

            if (customUser == null)
                return false;

            CustomIdentity customIdentity = new CustomIdentity(customUser.Username);

            CustomPrincipal customPrincipal = new CustomPrincipal(customIdentity, customUser);

            HttpContext.Current.User = customPrincipal;

            return true;
        }


        public bool AuthenticateUser(String user_name, String password,int rol)
        {
            CustomUser customUser = GetUserImplementationRol(user_name, password,rol);

            if (customUser == null)
                return false;

            CustomIdentity customIdentity = new CustomIdentity(customUser.Username);

            CustomPrincipal customPrincipal = new CustomPrincipal(customIdentity, customUser);

            HttpContext.Current.User = customPrincipal;

            return true;
        }
    }
}
