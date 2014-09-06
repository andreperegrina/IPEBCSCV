using IPEBCSCV.BusinessEntity;
using IPEBCSCV.BusinessLogic.Manager;
using IPEBCSCV.BusinessLogic.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace IPEBCSCV.Util
{
    public class CustomRoleProvider : RoleProvider
    {


        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //List<string> roles = new List<string>();

            //string role = ServiceLocator.Instance.GetService<UsuarioManager>().GetUsuarioPorLogin(username,"").rol.Nombre;

            //roles.Add(role);

            //return roles.ToArray();

            List<string> roles = new List<string>();

            List<Usuario> listaDeUsuarios = ServiceLocator.Instance.GetService<UsuarioManager>().GetUsuariosByNombreUsuario(username);
            foreach (var item in listaDeUsuarios)
            {
                roles.Add(item.rol.Nombre);
            }

            return roles.ToArray();

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}