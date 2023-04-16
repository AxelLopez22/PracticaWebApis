using System;
using System.Collections.Generic;

namespace ApiAutores.Models
{
    public partial class Libro
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }
        public bool? Estado { get; set; }
        public int? IdAutor { get; set; }

        public virtual Autor? IdAutorNavigation { get; set; }
    }
}
