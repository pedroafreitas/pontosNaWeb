using OneMoreApi.Models;
using System.Collections.Generic;

namespace OneMoreApi.Repository
{
    public interface IUsuarioRepository
    {
        void add(Usuario user);

        IEnumerable<Usuario> GetAll();

        Usuario Find(long id);

        void Remove(long id);

        void Update(Usuario user);
    }
}