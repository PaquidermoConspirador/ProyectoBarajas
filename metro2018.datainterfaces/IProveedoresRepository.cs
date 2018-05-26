using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataInterfaces
{
    using Types;

    public interface IProveedoresRepository
    {
        void NewProveedor(Proveedor proveedor);
        bool ProveedorIsAlreadyRegistered(string nombre);

        // CRUD - Create, Read, Update, Delete

        Task Create(Proveedor newObj);
        Task<IEnumerable<Proveedor>> ReadAll();
        Task<Proveedor> ReadById(int id);
        Task Update(Proveedor updatedObj);
        Task DeleteById(int id);
    }
}
