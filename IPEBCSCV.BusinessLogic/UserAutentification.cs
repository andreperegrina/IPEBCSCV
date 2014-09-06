using IPEBCSCV.BusinessEntity;
using Common.Data;
using IPEBCSCV.BusinessLogic.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic
{
    public class UserAutentification
    {

        private static UserAutentification instance;

        public static UserAutentification Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserAutentification();

                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public PerfilUsuario GetPerfilUsuario(String nombre_usuario, String contraseña)
        {


            Usuario usuario = ServiceLocator.ServiceLocator.Instance
                .GetService<UsuarioManager>().GetUsuarioPorLoginNoBaja(nombre_usuario, contraseña);

            if (usuario == null)
                return null;
            else
            {
                return new PerfilUsuario(usuario);
            }
        }


        public PerfilUsuario GetPerfilUsuarioByRol(String nombre_usuario, String contraseña, int rol, int usuarioID)
        {


            Usuario usuario = ServiceLocator.ServiceLocator.Instance
                .GetService<UsuarioManager>().GetUsuarioByNombreUsuarioAndRol(nombre_usuario, rol, usuarioID);

            if (usuario == null)
                return null;
            else
            {
                return new PerfilUsuario(usuario);
            }
        }
    
    }
}
