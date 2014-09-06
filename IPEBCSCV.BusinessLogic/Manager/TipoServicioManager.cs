using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class TipoServicioManager
    {


        DataAccess<TipoServicio> tipoServicioDAO = new DataAccess<TipoServicio>();

        public List<TipoServicio> GetAll()
        {
            return tipoServicioDAO.FindAll();
        }

        public int Save(TipoServicio nuevaTipoServicio)
        {
            return tipoServicioDAO.Save(nuevaTipoServicio);
        }

        public int Remove(TipoServicio tipoServicioRemove)
        {

            return tipoServicioDAO.Delete(tipoServicioRemove);
        }

        public int Update(TipoServicio editTipoServicio)
        {
            return tipoServicioDAO.Update(editTipoServicio);
        }

        public TipoServicio GetByID(int tipoServicioID)
        {
            return tipoServicioDAO.Find(e => e.TipoServicioId == tipoServicioID);
        }

        public List<TipoServicio> FindByAnything(string findValue)
        {
            return tipoServicioDAO.Search(e => e.Nombre.Contains(findValue));
        }
    }
}
