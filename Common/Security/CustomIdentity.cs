
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Common.Security
{
    public class CustomIdentity : IIdentity
    {
        private String name;
        private bool autenticated;


        public CustomIdentity(String name)
        {
            this.name = name;
            autenticated = true;
        }


        #region IIdentity Members

        public string AuthenticationType
        {
            get { return String.Empty; }
        }

        public bool IsAuthenticated
        {
            get { return autenticated; }
        }

        public string Name
        {
            get { return name; }        
        }

        #endregion
    }
}
