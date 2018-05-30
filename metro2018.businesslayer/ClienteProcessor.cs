using Metro2018.BusinessInterfaces;
using Metro2018.DataInterfaces;
using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metro2018.BusinessLayer
{
    public class ClienteProcessor : IClientesProcessor
    {
        private readonly IClientesRepository _clienteRepository;

        public ClienteProcessor(IClientesRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        async Task IClientesProcessor.DeleteById(int id)
        {
            try
            {
                await _clienteRepository.DeleteById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IClientesProcessor.Create(Cliente newObj)
        {
            try
            {
                await _clienteRepository.Create(newObj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<Cliente>> IClientesProcessor.ReadAll()
        {
            try
            {
                return await _clienteRepository.ReadAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<Cliente> IClientesProcessor.ReadById(int id)
        {
            try
            {
                return await _clienteRepository.ReadById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IClientesProcessor.Update(Cliente updatedObj)
        {
            try
            {
                await _clienteRepository.Update(updatedObj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
