using IPEBCSCV.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPEBCSCV.Report
{
    public class Bitacora
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Placas { get; set; }
        public string Serie { get; set; }
        public string NumeroEconomico { get; set; }
        public string Ubicacion { get; set; }
        public List<Servicio> ListaServicios { get; set; }
        public double ImporteTotal { get; set; }

        public Bitacora(Vehiculo vehiculo)
        {
            Marca = vehiculo.marca_vehiculo.Nombre;
            Modelo = vehiculo.Modelo;
            Color = vehiculo.Color;
            Placas = vehiculo.Placas;
            Serie = vehiculo.Serie;
            NumeroEconomico = vehiculo.NumeroEconomico.ToString();
            Ubicacion = vehiculo.municipio.Nombre;
            ListaServicios = vehiculo.servicio.ToList();

            foreach (var item in ListaServicios)
            {
                ImporteTotal += item.Importe;
            }

        }
        
    }
}
