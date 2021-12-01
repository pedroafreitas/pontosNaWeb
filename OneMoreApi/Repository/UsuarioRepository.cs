
using System.Collections.Generic;
using OneMoreApi.Models;
using System.Linq;

namespace OneMoreApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _context;
        
        public UsuarioRepository (UsuarioDbContext ctx)
        {
            _context = ctx;    
        }

        public void add(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public Usuario Find(long id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
           return _context.Usuarios.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.Usuarios.First(u => u.UsuarioId == id);
            _context.Usuarios.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Usuario user)
        {
            _context.Usuarios.Update(user);
            _context.SaveChanges();
        }
    }
}