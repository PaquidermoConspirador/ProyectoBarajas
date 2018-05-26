using Metro2018.BusinessInterfaces;
using Metro2018.DataInterfaces;
using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessLayer
{
    public class TareasProcessor : ITareasProcessor
    {
        private readonly ITareasRepository _tareaRepository;

        public TareasProcessor(ITareasRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        async Task ITareasProcessor.DeleteById(int id)
        {
            try
            {
                await _tareaRepository.DeleteById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task ITareasProcessor.Create(Tarea newObj)
        {
            try
            {
                await _tareaRepository.Create(newObj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<Tarea>> ITareasProcessor.ReadAll()
        {
            try
            {
                return await _tareaRepository.ReadAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<Tarea> ITareasProcessor.ReadById(int id)
        {
            try
            {
                return await _tareaRepository.ReadById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task ITareasProcessor.Update(Tarea updatedObj)
        {
            try
            {
                await _tareaRepository.Update(updatedObj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
