using System;
using System.Collections.Generic;

#nullable disable

namespace Act4Disneypixar.Models
{
    public partial class Aparicione
    {
        public int Id { get; set; }
        public int IdPersonaje { get; set; }
        public int IdPelicula { get; set; }

        public virtual Pelicula IdPeliculaNavigation { get; set; }
        public virtual Personaje IdPersonajeNavigation { get; set; }
    }
}
