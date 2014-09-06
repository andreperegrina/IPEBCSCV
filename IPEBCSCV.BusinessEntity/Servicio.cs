//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPEBCSCV.BusinessEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servicio
    {
        public int ServicioId { get; set; }
        public string Nombre { get; set; }
        public string Factura { get; set; }
        public string Proveedor { get; set; }
        public double Importe { get; set; }
        public System.DateTime FechaServicio { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int TipoServicioId { get; set; }
        public int VehiculoId { get; set; }
        public int UsuarioId { get; set; }
        public int Kilometraje { get; set; }
    
        public virtual TipoServicio tipo_servicio { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual Vehiculo vehiculo { get; set; }
    }
}