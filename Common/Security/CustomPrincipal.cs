using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Common.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private IIdentity identity;
        private CustomUser user;

        public CustomPrincipal(IIdentity identity, CustomUser user)
        {
           
            this.identity = identity;
            this.user = user;
        }

        public IIdentity Identity
        {
            get{ return identity; }
        }

        public CustomUser User
        {
            get { return user; }
        }

        public string Username
        {
            get{ return user.Username; }
        }

        public bool IsInRole(string role)
        {
            return true;
        }       
    }
}
