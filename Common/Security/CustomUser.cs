using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Security
{
    public interface CustomUser
    {
      //  private string user_name;

        //public CustomUser(string user_name);
        //{
        //    this.user_name = user_name;
        //}

        String Username
        {
            get;
        }

        bool IsInRole(string role);        
    }
}
