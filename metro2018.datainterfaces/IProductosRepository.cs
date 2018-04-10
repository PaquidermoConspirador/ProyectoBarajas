using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataInterfaces
{
    using Types;

    public interface IProductosRepository
    {
        void NewProduct(Producto producto);
        bool ProductIsAlreadyRegistered(string nombre);

        // CRUD - Create, Read, Update, Delete

        Task Create(Producto newObj);
        Task<IEnumerable<Producto>> ReadAll();
        Task<Producto> ReadById();
        Task Update(Producto updatedObj);
    }
}
