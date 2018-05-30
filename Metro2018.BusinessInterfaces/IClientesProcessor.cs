using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessInterfaces
{
    public interface IClientesProcessor
    {
        Task Create(Cliente newObj);
        Task<IEnumerable<Cliente>> ReadAll();
        Task<Cliente> ReadById(int id);
        Task Update(Cliente updatedObj);
        Task DeleteById(int id);
    }
}
