using System;
using System.Collections.Generic;

#nullable disable

namespace Act4Disneypixar.Models
{
    public partial class Cortometraje
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
    }
}
