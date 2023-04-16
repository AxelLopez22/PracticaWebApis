using ApiAutores.Dto;
using ApiAutores.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAutores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _services;

        public AutoresController(IAutorServices services)
        {
            _services = services;
        }

        [HttpPost("AgregarAutor")]
        public async Task<IActionResult> AgregarAutor(AutorDTO model)
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.AgregarAutor(model);

            if (result == false)
            {
                res.status = "Error";
                res.data = "Ocurrio un error al crear el autor";
                return BadRequest(res);
            }

            res.status = "Ok";
            res.data = "El autor se creo correctamente";
            return Ok(res);
        }

        [HttpGet("listarAutor")]
        public async Task<IActionResult> ListarAutores()
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.ListarAutores();

            if(result == null)
            {
                res.status = "Error";
                res.data = "No hay autores para mostrar";
                return BadRequest(res);
            }

            res.status = "Ok";
            res.data = result;

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerAutorId(int id)
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.ObtenerAutorId(id);

            if(result == null)
            {
                res.status = "Error";
                res.data = "El autor no existe";
                return BadRequest(res);
            }

            res.status = "Ok";
            res.data = result;

            return Ok(res);
        }

        [HttpPut("actualizarAutor/{id}")]
        public async Task<IActionResult> ActualizarAutor(int id, AutorDTO model)
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.ActualizarAutor(id, model);

            if (result == false)
            {
                res.status = "Error";
                res.data = "Ocurrio un error al actualizar el autor";
                return BadRequest(res);
            }

            res.status = "Ok";
            res.data = "El autor se actualizo correctamente";
            return Ok(res);
        }

        [HttpDelete("eliminarAutor/{id}")]
        public async Task<IActionResult> EliminarAutor(int id)
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.EliminarAutor(id);

            if(result == false)
            {
                res.status = "Error";
                res.data = "Ocurrio un error al eliminar el autor";

                return BadRequest(res);
            }

            res.status = "Ok";
            res.data = "Autor eliminado con exito";
            return Ok(res);
        }

    }
}
