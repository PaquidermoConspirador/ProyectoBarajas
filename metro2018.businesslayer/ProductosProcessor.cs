using Metro2018.BusinessInterfaces;
using Metro2018.DataInterfaces;
using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Metro2018.BusinessLayer
{
    public class ProductosProcessor : IProductosProcessor
    {
        private readonly IProductosRepository _productoRepository;

        public ProductosProcessor(IProductosRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        async Task IProductosProcessor.DeleteById(int id)
        {
            try
            {
                await _productoRepository.DeleteById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IProductosProcessor.Create(Producto newObj)
        {
            try
            {
                await _productoRepository.Create(newObj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<Producto>> IProductosProcessor.ReadAll()
        {
            try
            {
                return await _productoRepository.ReadAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<Producto> IProductosProcessor.ReadById(int id)
        {
            try
            {
                return await _productoRepository.ReadById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IProductosProcessor.Update(Producto updatedObj)
        {
            try
            {
                await _productoRepository.Update(updatedObj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
