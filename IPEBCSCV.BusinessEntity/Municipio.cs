
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
    
public partial class Municipio
{

    public Municipio()
    {

        this.vehiculo = new HashSet<Vehiculo>();

        this.usuario = new HashSet<Usuario>();

    }


    public int MunicipioId { get; set; }

    public string Nombre { get; set; }

    public System.DateTime FechaCreacion { get; set; }



    public virtual ICollection<Vehiculo> vehiculo { get; set; }

    public virtual ICollection<Usuario> usuario { get; set; }

}

}
