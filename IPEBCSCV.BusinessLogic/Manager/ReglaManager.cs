using Common.Data;
using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.Manager
{
    public class ReglaManager
    {


        DataAccess<Regla> reglaDAO = new DataAccess<Regla>();

        public List<Regla> GetAll()
        {
            return reglaDAO.FindAll();
        }

        public int Save(Regla nuevaRegla)
        {
            return reglaDAO.Save(nuevaRegla);
        }

        public int Remove(Regla reglaRemove)
        {

            return reglaDAO.Delete(reglaRemove);
        }

        public int Update(Regla editRegla)
        {
            return reglaDAO.Update(editRegla);
        }

        public Regla GetByID(int reglaID)
        {
            return reglaDAO.Find(e => e.ReglaId == reglaID);
        }

        public List<Regla> FindByAnything(string findValue)
        {
            return reglaDAO.Search(e => e.Nombre.Contains(findValue));
        }
    }
}
