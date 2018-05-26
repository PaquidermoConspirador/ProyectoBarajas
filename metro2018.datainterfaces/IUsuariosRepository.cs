using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataInterfaces
{
    using Types;

    public interface IUsuariosRepository
    {
        void NewUsuario(Usuario usuario);
        bool UsuarioIsAlreadyRegistered(string nombre);

        // CRUD - Create, Read, Update, Delete

        Task Create(Usuario newObj);
        Task<IEnumerable<Usuario>> ReadAll();
        Task<Usuario> ReadById(int id);
        Task Update(Usuario updatedObj);
        Task DeleteById(int id);
    }
}
