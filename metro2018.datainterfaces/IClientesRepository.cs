using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataInterfaces
{
    using Types;

    public interface IClientesRepository
    {
        void NewCliente(Cliente insumo);
        bool ClienteIsAlreadyRegistered(string nombre);

        // CRUD - Create, Read, Update, Delete

        Task Create(Cliente newObj);
        Task<IEnumerable<Cliente>> ReadAll();
        Task<Cliente> ReadById(int id);
        Task Update(Cliente updatedObj);
        Task DeleteById(int id);
    }
}
