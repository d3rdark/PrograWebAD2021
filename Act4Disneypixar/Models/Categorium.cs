using System;
using System.Collections.Generic;

#nullable disable

namespace Act4Disneypixar.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Cortometrajes = new HashSet<Cortometraje>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cortometraje> Cortometrajes { get; set; }
    }
}
