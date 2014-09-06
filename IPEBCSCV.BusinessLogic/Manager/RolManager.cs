using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class RolManager
    {


        DataAccess<Rol> rolDAO = new DataAccess<Rol>();

        public List<Rol> GetAll()
        {
            return rolDAO.FindAll();
        }

        public int Save(Rol nuevaRol)
        {
            return rolDAO.Save(nuevaRol);
        }

        public int Remove(Rol rolRemove)
        {

            return rolDAO.Delete(rolRemove);
        }

        public int Update(Rol editRol)
        {
            return rolDAO.Update(editRol);
        }

        public Rol GetByID(int rolID)
        {
            return rolDAO.Find(e => e.RolId == rolID);
        }

        public List<Rol> FindByAnything(string findValue)
        {
            return rolDAO.Search(e => e.Nombre.Contains(findValue));
        }
    }
}
