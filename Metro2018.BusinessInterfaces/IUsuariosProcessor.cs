using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessInterfaces
{
    using Types;

    public interface IUsuariosProcessor
    {
        Task Create(Usuario newObj);
        Task<IEnumerable<Usuario>> ReadAll();
        Task<Usuario> ReadById(int id);
        Task Update(Usuario updatedObj);
        Task DeleteById(int id);
    }
}
