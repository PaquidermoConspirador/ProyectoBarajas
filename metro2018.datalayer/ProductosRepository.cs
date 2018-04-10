using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer
{
    using DataInterfaces;
    using Types;

    public class ProductosRepository : IProductosRepository
    {
        public Task Create(Producto newObj)
        {
            throw new NotImplementedException();
        }

        public void NewProduct(Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool ProductIsAlreadyRegistered(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Producto> ReadById()
        {
            throw new NotImplementedException();
        }

        public Task Update(Producto updatedObj)
        {
            throw new NotImplementedException();
        }
    }
}
