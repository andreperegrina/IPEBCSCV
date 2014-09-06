using Common.Security;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic
{
    public class PerfilUsuario : CustomUser
    {

        private Usuario usuario;

        public Usuario Usuario { get; set; }

        public string Password { get; set; }

        public PerfilUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        #region CustomUser Members

        public string Username
        {
            get
            {
                if (usuario == null)
                    return null;

                return this.usuario.NombreUsuario;
            }
        }

        public bool IsInRole(string role)
        {
            try
            {
                if (this.usuario.rol.Nombre.Equals(role))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
 
        public bool IsInRole(HashSet<int> roles)
        {
            try
            {
                return roles.Contains(this.usuario.rol.RolId);
            }
            catch
            {
                return false;
            }
        }

        public int RolID()
        {
            try
            {
                return this.usuario.RolId;
            }
            catch
            {
                return -1;
            }
        }
        public string GetRol()
        {
            try
            {
                return this.usuario.rol.Nombre;
            }
            catch
            {
                return "";
            }
        }

        public string GetNombre()
        {
            return usuario.NombreCompleto;
        }

        #endregion

        #region PerfilUsuario Members

        public int UsuarioId
        {
            get
            {
                if (usuario == null)
                    return 0;

                return this.usuario.UsuarioId;
            }
        }
        #endregion
    }
}
