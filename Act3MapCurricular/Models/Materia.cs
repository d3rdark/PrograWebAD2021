using System;
using System.Collections.Generic;

#nullable disable

namespace Act3MapCurricular.Models
{
    public partial class Materia
    {
        public uint Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public sbyte HorasTeoricas { get; set; }
        public sbyte HorasPracticas { get; set; }
        public byte Creditos { get; set; }
        public byte Semestre { get; set; }
        public int IdCarrera { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
    }
}
