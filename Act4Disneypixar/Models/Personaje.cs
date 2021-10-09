using System;
using System.Collections.Generic;

#nullable disable

namespace Act4Disneypixar.Models
{
    public partial class Personaje
    {
        public Personaje()
        {
            Apariciones = new HashSet<Aparicione>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Aparicione> Apariciones { get; set; }
    }
}
