using System;
using System.Collections.Generic;

#nullable disable

namespace Act2PresidenteMexico.Models
{
    public partial class Presidente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaFallecimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public int? IdEstadoRepublica { get; set; }
        public string Ocupacion { get; set; }
        public DateTime InicioGobierno { get; set; }
        public DateTime? TerminoGobierno { get; set; }
        public int IdPartidoPolitico { get; set; }
        public string Biografia { get; set; }

        public virtual Estadorepublica IdEstadoRepublicaNavigation { get; set; }
        public virtual Partidopolitico IdPartidoPoliticoNavigation { get; set; }
    }
}
