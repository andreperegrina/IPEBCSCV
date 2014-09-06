using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class MarcaVehiculoManager
    {

        DataAccess<MarcaVehiculo> marcaVehiculoDAO = new DataAccess<MarcaVehiculo>();

        public List<MarcaVehiculo> GetAll()
        {
            return marcaVehiculoDAO.FindAll();
        }

        public int Save(MarcaVehiculo nuevaMarcaVehiculo)
        {
            return marcaVehiculoDAO.Save(nuevaMarcaVehiculo);
        }

        public int Remove(MarcaVehiculo marcaVehiculoRemove)
        {

            return marcaVehiculoDAO.Delete(marcaVehiculoRemove);
        }

        public int Update(MarcaVehiculo editMarcaVehiculo)
        {
            return marcaVehiculoDAO.Update(editMarcaVehiculo);
        }

        public MarcaVehiculo GetByID(int marcaVehiculoID)
        {
            return marcaVehiculoDAO.Find(e => e.MarcaVehiculoId == marcaVehiculoID);
        }

        public List<MarcaVehiculo> FindByAnything(string findValue)
        {
            return marcaVehiculoDAO.Search(e => e.Nombre.Contains(findValue));
        }
    }
}
