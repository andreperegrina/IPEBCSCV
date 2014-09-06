using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class RevisionVehiculoManager
    {


        DataAccess<RevisionVehiculo> revisionVehiculoDAO = new DataAccess<RevisionVehiculo>();

        public List<RevisionVehiculo> GetAll()
        {
            return revisionVehiculoDAO.FindAll();
        }

        public int Save(RevisionVehiculo nuevaRevisionVehiculo)
        {
            return revisionVehiculoDAO.Save(nuevaRevisionVehiculo);
        }

        public int Remove(RevisionVehiculo revisionVehiculoRemove)
        {

            return revisionVehiculoDAO.Delete(revisionVehiculoRemove);
        }

        public int Update(RevisionVehiculo editRevisionVehiculo)
        {
            return revisionVehiculoDAO.Update(editRevisionVehiculo);
        }

        public RevisionVehiculo GetByID(int revisionVehiculoID)
        {
            return revisionVehiculoDAO.Find(e => e.RevisionVehiculoId == revisionVehiculoID);
        }

        public int GetKilometrajeSugerido(DateTime dateServices)
        {
            RevisionVehiculo revisionVehiculoDAOFind = revisionVehiculoDAO.Find(e => e.FechaRevision <= dateServices);
            return revisionVehiculoDAOFind!=null ?revisionVehiculoDAOFind.Kilometraje:0;
        }

        public List<RevisionVehiculo> FindByAnything(string findValue)
        {
            return revisionVehiculoDAO.Search(e => e.Placas.Contains(findValue));
        }
    }
}
