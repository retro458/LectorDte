using System;
using System.Collections.Generic;

namespace LectorDte.API.Models;

public partial class ClasificacionProveedor
{
    public int Id { get; set; }

    public string NitEmpresa { get; set; } = null!;

    public string NitProveedor { get; set; } = null!;

    public string NombreProveedor { get; set; } = null!;

    public byte Clasificacion { get; set; }

    public byte Sector { get; set; }

    public byte TipoCostoGasto { get; set; }

    public DateTime FechaActualizacion { get; set; }
}
