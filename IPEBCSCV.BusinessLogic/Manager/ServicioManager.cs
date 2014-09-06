using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class ServicioManager
    {


        DataAccess<Servicio> servicioDAO = new DataAccess<Servicio>();

        public List<Servicio> GetAll()
        {
            return servicioDAO.FindAll();
        }

        public int Save(Servicio nuevaServicio)
        {
            return servicioDAO.Save(nuevaServicio);
        }

        public int Remove(Servicio servicioRemove)
        {

            return servicioDAO.Delete(servicioRemove);
        }

        public int Update(Servicio editServicio)
        {
            return servicioDAO.Update(editServicio);
        }

        public Servicio GetByID(int servicioID)
        {
            return servicioDAO.Find(e => e.ServicioId == servicioID);
        }

        public List<Servicio> FindByAnything(string findValue)
        {
            return servicioDAO.Search(e => e.Nombre.Contains(findValue));
        }
    }
}
