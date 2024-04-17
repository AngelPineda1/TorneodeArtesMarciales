using System;
using System.Collections.Generic;

#nullable disable

namespace TorneodeArtesMarciales.Models
{
    public partial class Artesmarciales
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valores { get; set; }
        public int? AñoOrigen { get; set; }
        public int? Variantes { get; set; }
        public string LugarOrigen { get; set; }
    }
}
