using ApiAutores.Context;
using ApiAutores.Dto;
using ApiAutores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAutores.Sevices
{
    public class AutorServices : IAutorServices
    {
        private readonly AutoresContext _context;

        public AutorServices(AutoresContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarAutor(int id, AutorDTO model)
        {
            try
            {
                var autor = await _context.Autors.Where(x => x.Estado == true && x.IdAutor == id).FirstOrDefaultAsync();

                if (autor == null) { return false; }

                autor.Nombres = model.Nombres;
                autor.Apellidos = model.Apellidos;
                autor.Direccion = model.Direccion;
                autor.Correo = model.Correo;
                autor.Celular = model.Celular;

                _context.Autors.Update(autor);
                await _context.SaveChangesAsync();

                return true;
            } 
            catch
            {
                return false;
            }
        }

        public async Task<bool> AgregarAutor(AutorDTO autor)
        {
            try
            {
                Autor model = new Autor();
                model.Nombres = autor.Nombres;
                model.Apellidos = autor.Apellidos;
                model.Celular = autor.Celular;
                model.Correo = autor.Correo;
                model.Direccion = autor.Direccion;
                model.Estado = true;

                await _context.Autors.AddAsync(model);
                await _context.SaveChangesAsync();

                return true;
            } 
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarAutor(int id)
        {
            var autor = await _context.Autors.Where(x => x.Estado == true && x.IdAutor == id).FirstOrDefaultAsync();
            if (autor == null) { return false; }

            autor.Estado = false;

            _context.Autors.Update(autor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<AutorDTO>> ListarAutores()
        {
            var autores = await _context.Autors.Where(x => x.Estado == true)
                .Select(s => new AutorDTO()
                {
                    Nombres = s.Nombres,
                    Apellidos = s.Apellidos,
                    Direccion = s.Direccion,
                    Correo = s.Correo,
                    Celular = (int)s.Celular
                }).ToListAsync();

            if(autores.Count() == 0)
            {
                return null;
            }

            return autores;
        }

        public async Task<AutorDTO> ObtenerAutorId(int id)
        {
            var autor = await _context.Autors.Where(x => x.Estado == true && x.IdAutor == id)
                .Select(s => new AutorDTO()
                {
                    Nombres = s.Nombres,
                    Apellidos = s.Apellidos,
                    Direccion = s.Direccion,
                    Correo = s.Correo,
                    Celular = (int)s.Celular
                }).FirstOrDefaultAsync();

            return autor;
        }
    }


    public interface IAutorServices
    {
        Task<bool> AgregarAutor(AutorDTO autor);
        Task<List<AutorDTO>> ListarAutores();
        Task<AutorDTO> ObtenerAutorId(int id);
        Task<bool> ActualizarAutor(int id, AutorDTO model);
        Task<bool> EliminarAutor(int id);
    }
}
