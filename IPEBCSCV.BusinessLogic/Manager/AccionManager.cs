using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class AccionManager
    {


        DataAccess<Accion> accionDAO = new DataAccess<Accion>();

        public List<Accion> GetAll()
        {
            return accionDAO.FindAll();
        }

        public int Save(Accion nuevaAccion)
        {
            return accionDAO.Save(nuevaAccion);
        }

        public int Remove(Accion accionRemove)
        {

            return accionDAO.Delete(accionRemove);
        }

        public int Update(Accion editAccion)
        {
            return accionDAO.Update(editAccion);
        }

        public Accion GetByID(int accionID)
        {
            return accionDAO.Find(e => e.AccionId == accionID);
        }

        public List<Accion> FindByAnything(string findValue)
        {
            return accionDAO.Search(e => e.Descripcion.Contains(findValue));
        }
    }
}
