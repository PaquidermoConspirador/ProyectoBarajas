using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessInterfaces
{
    using Types;

    public interface IDepartamentosProcessor
    {
        Task Create(Departamento newObj);
        Task<IEnumerable<Departamento>> ReadAll();
        Task<Departamento> ReadById(int id);
        Task Update(Departamento updatedObj);
        Task DeleteById(int id);

    }
}
