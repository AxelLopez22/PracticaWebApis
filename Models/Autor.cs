using System;
using System.Collections.Generic;

namespace ApiAutores.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdAutor { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Correo { get; set; }
        public int? Celular { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
