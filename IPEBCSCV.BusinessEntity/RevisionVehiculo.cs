
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
    
public partial class RevisionVehiculo
{

    public int RevisionVehiculoId { get; set; }

    public string Espejos { get; set; }

    public string Focos { get; set; }

    public string Llantas { get; set; }

    public string Puertas { get; set; }

    public string Manijas { get; set; }

    public string Parabrisas { get; set; }

    public string Antena { get; set; }

    public string Carroceria { get; set; }

    public string Placas { get; set; }

    public int Kilometraje { get; set; }

    public string NombreUsuario { get; set; }

    public string Observaciones { get; set; }

    public System.DateTime FechaCreacion { get; set; }

    public System.DateTime FechaRevision { get; set; }

    public int UsuarioId { get; set; }

    public int VehiculoId { get; set; }



    public virtual Usuario usuario { get; set; }

    public virtual Vehiculo vehiculo { get; set; }

}

}
