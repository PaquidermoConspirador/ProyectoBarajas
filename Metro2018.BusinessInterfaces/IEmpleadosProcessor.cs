using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessInterfaces
{
    using Types;

    public interface IEmpleadosProcessor
    {
        Task Create(Empleado newObj);
        Task<IEnumerable<Empleado>> ReadAll();
        Task<Empleado> ReadById(int id);
        Task Update(Empleado updatedObj);
        Task DeleteById(int id);
    }
}
