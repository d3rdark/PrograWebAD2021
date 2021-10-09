using System;
using System.Collections.Generic;

#nullable disable

namespace Act4Disneypixar.Models
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Apariciones = new HashSet<Aparicione>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreOriginal { get; set; }
        public string Descripción { get; set; }
        public DateTime? FechaEstreno { get; set; }

        public virtual ICollection<Aparicione> Apariciones { get; set; }
    }
}
