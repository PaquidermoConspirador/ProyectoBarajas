using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessInterfaces
{
    public interface IProveedoresProcessor
    {
        Task Create(Proveedor newObj);
        Task<IEnumerable<Proveedor>> ReadAll();
        Task<Proveedor> ReadById(int id);
        Task Update(Proveedor updatedObj);
        Task DeleteById(int id);
    }
}
