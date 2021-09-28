using System;
using System.Collections.Generic;

#nullable disable

namespace Act2PresidenteMexico.Models
{
    public partial class Estadorepublica
    {
        public Estadorepublica()
        {
            Presidentes = new HashSet<Presidente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Presidente> Presidentes { get; set; }
    }
}
