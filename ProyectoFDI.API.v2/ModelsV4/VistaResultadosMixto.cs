using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.v2.ModelsV4
{
    public partial class VistaResultadosMixto
    {
        public int? IdCom { get; set; }
        public int? IdDep { get; set; }
        public string? NombreDeportista { get; set; }
        public decimal? TotalResultadoBloque { get; set; }
        public int? TotalPuntosDificultad { get; set; }
        public decimal? TotalFinal { get; set; }
    }
}
