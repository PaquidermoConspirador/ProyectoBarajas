using Metro2018.BusinessInterfaces;
using Metro2018.DataInterfaces;
using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Metro2018.BusinessLayer
{
    public class ProveedoresProcessor : IProveedoresProcessor
    {
        private readonly IProveedoresRepository _proveedorRepository;

        public ProveedoresProcessor(IProveedoresRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        async Task IProveedoresProcessor.DeleteById(int id)
        {
            try
            {
                await _proveedorRepository.DeleteById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IProveedoresProcessor.Create(Proveedor newObj)
        {
            try
            {
                await _proveedorRepository.Create(newObj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<Proveedor>> IProveedoresProcessor.ReadAll()
        {
            try
            {
                return await _proveedorRepository.ReadAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<Proveedor> IProveedoresProcessor.ReadById(int id)
        {
            try
            {
                return await _proveedorRepository.ReadById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IProveedoresProcessor.Update(Proveedor updatedObj)
        {
            try
            {
                await _proveedorRepository.Update(updatedObj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
