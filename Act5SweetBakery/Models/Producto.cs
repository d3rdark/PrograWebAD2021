using System;
using System.Collections.Generic;

#nullable disable

namespace Act5SweetBakery.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
    }
}
