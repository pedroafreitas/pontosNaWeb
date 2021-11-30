using System.Collections.Generic;
using System.Linq;
using OneMoreApi.Models;

namespace OneMoreApi.Repository
{
    public class InMemoryUsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> usuarios = new()
        {
            //id, nome, senha email
            new Usuario { UsuarioId = 1, Nome = "Anna Clara Pinto", Senha = "abc123", Email = "clara.anna@gmail.com"},
            new Usuario { UsuarioId = 2, Nome = "Pedro Arthur Freitas", Senha = "abc123", Email = "pedro@gmail.com"},
            new Usuario { UsuarioId = 3, Nome = "João Leonardo Freitas", Senha = "abc123", Email = "joao@gmail.com"},
            new Usuario { UsuarioId = 4, Nome = "Thiago Wallass", Senha = "abc123", Email = "thiago@gmail.com"},
            new Usuario { UsuarioId = 5, Nome = "Sandro Avelar", Senha = "abc123", Email = "sandro@gmail.com"},
        };

        public void add(Usuario user)
        {
            usuarios.Add(user);
        }

        public Usuario Find(long id)
        {
            return usuarios.Where(usuario => usuario.UsuarioId == id).
                                SingleOrDefault();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return usuarios;
        }

        public void Remove(long id)
        {
            var index = usuarios.FindIndex(existingItem => existingItem.UsuarioId == id);
            usuarios.RemoveAt(index);
        }

        public void Update(Usuario user)
        {
            var index = usuarios.FindIndex(existingItem => existingItem == user);
            usuarios[index] = user;
        }
    }
}