using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OneMoreApi.Models;
using OneMoreApi.Repository;

namespace OneMoreApi.Controllers
{

    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        //Metodos que vão expor os serviços da api

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        [HttpGet("{id}", Name="GetUsuario")]
        public IActionResult GetById(long id)
        {
            var usuario = _usuarioRepository.Find(id);
            if (usuario == null)
                return NotFound();

            return new ObjectResult(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if(usuario == null)
                return BadRequest();

            _usuarioRepository.add(usuario);

            return CreatedAtRoute("GetUsuario", new {id = usuario.UsuarioId}, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Usuario usuario)
        {
            if(usuario == null || usuario.UsuarioId != id)
                return BadRequest();
            
            var _usuario = _usuarioRepository.Find(id);

            if(usuario == null)
                return NotFound();

            _usuario.Nome = usuario.Nome;
            _usuario.Email = usuario.Email;

            _usuarioRepository.Update(_usuario);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var usuario = _usuarioRepository.Find(id);

            if(usuario == null)
                return NotFound();

            _usuarioRepository.Remove(id);
            
            return new NoContentResult();
        }

    }
}