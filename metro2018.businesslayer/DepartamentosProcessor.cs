using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessLayer
{
    using BusinessInterfaces;
    using DataInterfaces;
    using DataLayer;
    using Types;

    public class DepartamentosProcessor : IDepartamentosProcessor
    {
        private readonly IDepartamentosRepository _departamentosRepository;

        public DepartamentosProcessor(IDepartamentosRepository departamentosRepository)
        {
            _departamentosRepository = departamentosRepository;
        }

        async Task IDepartamentosProcessor.Create(Departamento newObj)
        {
            try
            {
                await _departamentosRepository.Create(newObj);
            }
            catch(Exception)
            {
                throw;
            }
        }
        async Task IDepartamentosProcessor.DeleteById(int id)
        {
            try
            {
                await _departamentosRepository.DeleteById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<Departamento>> IDepartamentosProcessor.ReadAll()
        {
            try
            {
                return await _departamentosRepository.ReadAll();
            }
            catch(Exception)
            {
                throw;
            }
        }

        async Task<Departamento> IDepartamentosProcessor.ReadById(int id)
        {
            try
            {
                return await _departamentosRepository.ReadById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IDepartamentosProcessor.Update(Departamento updatedObj)
        {
            try
            {
                await _departamentosRepository.Update(updatedObj);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
