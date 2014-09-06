using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class VehiculoManager
    {

        DataAccess<Vehiculo> vehiculoDAO = new DataAccess<Vehiculo>();

        public List<Vehiculo> GetAll()
        {
            return vehiculoDAO.FindAll();
        }

        public int Save(Vehiculo nuevaVehiculo)
        {
            return vehiculoDAO.Save(nuevaVehiculo);
        }

        public int Remove(Vehiculo vehiculoRemove)
        {

            return vehiculoDAO.Delete(vehiculoRemove);
        }

        public int Update(Vehiculo editVehiculo)
        {
            return vehiculoDAO.Update(editVehiculo);
        }

        public Vehiculo GetByID(int vehiculoID)
        {
            return vehiculoDAO.Find(e => e.VehiculoId == vehiculoID);
        }

        public List<Vehiculo> FindByAnything(string findValue)
        {
            return vehiculoDAO.Search(e => e.Modelo.Contains(findValue));
        }

    }
}
