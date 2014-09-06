using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class MunicipioManager
    {


        DataAccess<Municipio> municipioDAO = new DataAccess<Municipio>();

        public List<Municipio> GetAll()
        {
            return municipioDAO.FindAll();
        }

        public int Save(Municipio nuevaMunicipio)
        {
            return municipioDAO.Save(nuevaMunicipio);
        }

        public int Remove(Municipio municipioRemove)
        {

            return municipioDAO.Delete(municipioRemove);
        }

        public int Update(Municipio editMunicipio)
        {
            return municipioDAO.Update(editMunicipio);
        }

        public Municipio GetByID(int municipioID)
        {
            return municipioDAO.Find(e => e.MunicipioId == municipioID);
        }

        public List<Municipio> FindByAnything(string findValue)
        {
            return municipioDAO.Search(e => e.Nombre.Contains(findValue));
        }
    }
}
