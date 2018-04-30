using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessLayer
{
    using BusinessInterfaces;
    using Types;
    using DataInterfaces;

    public class InsumosProcessor : IInsumosProcessor
    {

        private readonly IInsumoRepository _insumoRepository;

        public InsumosProcessor(IInsumoRepository insumosRepository)
        {
            _insumoRepository = insumosRepository;
        }

        async Task IInsumosProcessor.Create(Insumo newObj)
        {
            try
            {
                await _insumoRepository.Create(newObj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<Insumo>> IInsumosProcessor.ReadAll()
        {
            try
            {
                return await _insumoRepository.ReadAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<Insumo> IInsumosProcessor.ReadById(int id)
        {
            try
            {
                return await _insumoRepository.ReadById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IInsumosProcessor.Update(Insumo updatedObj)
        {
            try
            {
                await _insumoRepository.Update(updatedObj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
