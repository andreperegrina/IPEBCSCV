using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.ServiceLocator
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}
