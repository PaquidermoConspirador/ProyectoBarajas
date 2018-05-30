using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataInterfaces
{
    using Types;

    public interface IEmpleadosRepository
    {
        void NewEmpleado(Empleado empleado);
        bool EmpleadoIsAlreadyRegistered(string nombre);

        // CRUD - Create, Read, Update, Delete

        Task Create(Empleado newObj);
        Task<IEnumerable<Empleado>> ReadAll();
        Task<Empleado> ReadById(int id);
        Task Update(Empleado updatedObj);
        Task DeleteById(int id);
    }
}
