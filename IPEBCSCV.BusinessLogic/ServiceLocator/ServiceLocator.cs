using IPEBCSCV.BusinessLogic.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.BusinessLogic.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {

        private readonly IDictionary<Type, Type> servicesType;
        private static readonly object TheLock = new Object();
        private static IServiceLocator instance;
        private readonly IDictionary<Type, object> instantiatedServices;
        private ServiceLocator()
        {
            this.servicesType = new Dictionary<Type, Type>();
            this.instantiatedServices = new Dictionary<Type, object>();
            this.BuildServiceTypesMap();
        }



        public static IServiceLocator Instance
        {
            get
            {
                lock (TheLock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceLocator();
                    }
                }
                return instance;
            }
        }

        public T GetService<T>()
        {
            if (this.instantiatedServices.ContainsKey(typeof(T)))
            {
                return (T)this.instantiatedServices[typeof(T)];
            }
            else
            {
                try
                {
                    ConstructorInfo constructor = servicesType[typeof(T)].GetConstructor(new Type[0]);
                    T service = (T)constructor.Invoke(null);
                    //instantiatedServices.Add(typeof(T), service);
                    return service;
                }
                catch (KeyNotFoundException)
                {
                    throw new ApplicationException("The requested service is not registered");
                }
            }
        }

        private void BuildServiceTypesMap()
        {
            #region Managers
            servicesType.Add(typeof(UsuarioManager), typeof(UsuarioManager));
            servicesType.Add(typeof(MunicipioManager), typeof(MunicipioManager));
            servicesType.Add(typeof(ReglaManager), typeof(ReglaManager));
            servicesType.Add(typeof(RevisionVehiculoManager), typeof(RevisionVehiculoManager));
            servicesType.Add(typeof(ServicioManager), typeof(ServicioManager));
            servicesType.Add(typeof(TipoServicioManager), typeof(TipoServicioManager));
            servicesType.Add(typeof(VehiculoManager), typeof(VehiculoManager));
            servicesType.Add(typeof(RolManager), typeof(RolManager));
            servicesType.Add(typeof(MarcaVehiculoManager), typeof(MarcaVehiculoManager));
            servicesType.Add(typeof(IncidenciaManager), typeof(IncidenciaManager));
            servicesType.Add(typeof(AccionManager), typeof(AccionManager));
            #endregion

        }
    }
}
