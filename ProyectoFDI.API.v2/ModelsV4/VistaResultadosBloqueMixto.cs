using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.v2.ModelsV4
{
    public partial class VistaResultadosBloqueMixto
    {
        public int? IdCom { get; set; }
        public int? IdDep { get; set; }
        public string? NombreDeportista { get; set; }
        public decimal? TotalResultado { get; set; }
    }
}
