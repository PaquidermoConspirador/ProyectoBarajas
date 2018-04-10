using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.UnitTests.Mocks
{
    using DataInterfaces;
    using Types;

    public class MockProductsRepository : IProductosRepository
    {
        public bool NewProductInvoked { get; private set; }
        public bool IsProductAlreadyRegisteredInvoked { get; private set; }

        public void Create(Producto producto)
        {
            NewProductInvoked = true;

            if (ProductIsAlreadyRegistered(producto.Nombre))
                throw new Exception("El producto ya está registrado");

            NewProductInvoked = true;
        }

        public bool ProductIsAlreadyRegistered(string nombre)
        {
            IsProductAlreadyRegisteredInvoked = true;

            if (nombre.Equals("Papabritas"))
                return true;
            else if (nombre.Equals("Problema"))
                throw new InvalidOperationException("Hubo un problema desde el mock de productos");
            else
                return false;
        }

        void IProductosRepository.NewProduct(Producto producto)
        {
            throw new NotImplementedException();
        }

        bool IProductosRepository.ProductIsAlreadyRegistered(string nombre)
        {
            throw new NotImplementedException();
        }

        Task IProductosRepository.Create(Producto newObj)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Producto>> IProductosRepository.ReadAll()
        {
            throw new NotImplementedException();
        }

        Task<Producto> IProductosRepository.ReadById()
        {
            throw new NotImplementedException();
        }

        Task IProductosRepository.Update(Producto updatedObj)
        {
            throw new NotImplementedException();
        }
    }
}
