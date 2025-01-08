using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.v2.ModelsV4
{
    public partial class Boulder
    {
        public int IdBoulder { get; set; }
        public int? IdCom { get; set; }
        public int? IdDep { get; set; }
        public int? NroBlo { get; set; }
        public int? Zona1 { get; set; }
        public int? Zona2 { get; set; }
        public int? Topr { get; set; }
        public int? Intentos { get; set; }

        public virtual Competencium? IdComNavigation { get; set; }
        public virtual Deportistum? IdDepNavigation { get; set; }
    }
}
