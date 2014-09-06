using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class IncidenciaManager
    {


        DataAccess<Incidencia> incidenciaDAO = new DataAccess<Incidencia>();

        public List<Incidencia> GetAll()
        {
            return incidenciaDAO.FindAll();
        }

        public int Save(Incidencia nuevaIncidencia)
        {
            return incidenciaDAO.Save(nuevaIncidencia);
        }

        public int Remove(Incidencia incidenciaRemove)
        {

            return incidenciaDAO.Delete(incidenciaRemove);
        }

        public int Update(Incidencia editIncidencia)
        {
            return incidenciaDAO.Update(editIncidencia);
        }

        public Incidencia GetByID(int incidenciaID)
        {
            return incidenciaDAO.Find(e => e.IncidenciaId == incidenciaID);
        }

        public List<Incidencia> FindByAnything(string findValue)
        {
            return incidenciaDAO.Search(e => e.Descripcion.Contains(findValue));
        }
    }
}
