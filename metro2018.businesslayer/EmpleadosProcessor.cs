using Metro2018.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metro2018.Types;
using Metro2018.DataInterfaces;

namespace Metro2018.BusinessLayer
{
    public class EmpleadosProcessor : IEmpleadosProcessor
    {
        private readonly IEmpleadosRepository _empleadosRepository;

        public EmpleadosProcessor(IEmpleadosRepository empleadosRepository)
        {
            _empleadosRepository = empleadosRepository;
        }

        async Task IEmpleadosProcessor.Create(Empleado newObj)
        {
            await _empleadosRepository.Create(newObj);
        }

        async Task IEmpleadosProcessor.DeleteById(int id)
        {
            await _empleadosRepository.DeleteById(id);
        }

        async Task<IEnumerable<Empleado>> IEmpleadosProcessor.ReadAll()
        {
            return await _empleadosRepository.ReadAll();
        }

        async Task<Empleado> IEmpleadosProcessor.ReadById(int id)
        {
            return await _empleadosRepository.ReadById(id);
        }

        async Task IEmpleadosProcessor.Update(Empleado updatedObj)
        {
            await _empleadosRepository.Update(updatedObj);
        }
    }
}
