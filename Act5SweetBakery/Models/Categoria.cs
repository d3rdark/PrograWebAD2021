using System;
using System.Collections.Generic;

#nullable disable

namespace Act5SweetBakery.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
            Receta = new HashSet<Receta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Receta> Receta { get; set; }
    }
}
