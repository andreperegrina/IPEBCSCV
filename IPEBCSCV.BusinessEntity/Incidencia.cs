
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
    
public partial class Incidencia
{

    public int IncidenciaId { get; set; }

    public string Descripcion { get; set; }

    public int VehiculoId { get; set; }

    public int UsuarioId { get; set; }

    public int AccionId { get; set; }



    public virtual Vehiculo vehiculo { get; set; }

    public virtual Accion accion { get; set; }

    public virtual Usuario usuario { get; set; }

}

}
