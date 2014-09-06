using Common.Data;
using Common.Security.Encrypt;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class UsuarioManager
    {
        DataAccess<Usuario> usuarioDAO = new DataAccess<Usuario>();

        public List<Usuario> GetAll()
        {
            return usuarioDAO.FindAll();
        }

        public int Save(Usuario nuevaUsuario)
        {
            return usuarioDAO.Save(nuevaUsuario);
        }

        public int Remove(Usuario usuarioRemove)
        {

            return usuarioDAO.Delete(usuarioRemove);
        }

        public int Update(Usuario editUsuario)
        {
            return usuarioDAO.Update(editUsuario);
        }

        public Usuario GetByID(int usuarioID)
        {
            return usuarioDAO.Find(e => e.UsuarioId == usuarioID);
        }

        public List<Usuario> FindByAnything(string findValue)
        {
            return usuarioDAO.Search(e=> e.NombreCompleto.Contains(findValue) && e.NombreUsuario.Contains(findValue));
        }

        public Usuario GetUsuarioByNombreUsuarioAndRol(string nombre_usuario, int rolID, int usuarioID)
        {
            nombre_usuario = nombre_usuario.ToUpper();
            return usuarioDAO.Find(e => e.NombreUsuario.ToUpper() == nombre_usuario
                && e.RolId == rolID && e.UsuarioId == usuarioID);
        }


        public List<Usuario> GetUsuariosByNombreUsuario(string nombre_usuario)
        {

            nombre_usuario = nombre_usuario.ToUpper();
            return usuarioDAO.Search(e => e.NombreUsuario.ToUpper() == nombre_usuario);
        }


        public Usuario GetUsuarioPorLoginNoBaja(string nombre_usuario, string contraseña)
        {

            nombre_usuario = nombre_usuario.ToUpper();
            contraseña = EncryptionUtil.Encrypt(contraseña);
            return usuarioDAO.Find(e => e.NombreUsuario.ToUpper() == nombre_usuario 
                && e.Password == contraseña && e.Baja == false);
        }

    }
}
