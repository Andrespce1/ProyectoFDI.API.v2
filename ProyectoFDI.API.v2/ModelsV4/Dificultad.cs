using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.v2.ModelsV4
{
    public partial class Dificultad
    {
        public int IdDificultad { get; set; }
        public int IdCom { get; set; }
        public int IdDep { get; set; }
        public string NroPresa { get; set; } = null!;
        public int Puntos { get; set; }

        public virtual Competencium IdComNavigation { get; set; } = null!;
        public virtual Deportistum IdDepNavigation { get; set; } = null!;
    }
}
