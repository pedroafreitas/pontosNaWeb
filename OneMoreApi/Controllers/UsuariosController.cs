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
    }
}