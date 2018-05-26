using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessLayer
{
    using Metro2018.BusinessInterfaces;
    using Metro2018.DataInterfaces;
    using Types;

    public class UsuariosProcessor : IUsuariosProcessor
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosProcessor(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        async Task IUsuariosProcessor.Create(Usuario newObj)
        {
            try
            {
                await _usuariosRepository.Create(newObj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IUsuariosProcessor.DeleteById(int id)
        {
            try
            {
                await _usuariosRepository.DeleteById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<Usuario>> IUsuariosProcessor.ReadAll()
        {
            try
            {
                return await _usuariosRepository.ReadAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<Usuario> IUsuariosProcessor.ReadById(int id)
        {
            try
            {
                return await _usuariosRepository.ReadById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IUsuariosProcessor.Update(Usuario updatedObj)
        {
            try
            {
                await _usuariosRepository.Update(updatedObj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
