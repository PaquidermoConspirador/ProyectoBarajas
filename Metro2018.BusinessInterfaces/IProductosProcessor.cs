using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessInterfaces
{
    public interface IProductosProcessor
    {
        Task Create(Producto newObj);
        Task<IEnumerable<Producto>> ReadAll();
        Task<Producto> ReadById(int id);
        Task Update(Producto updatedObj);
        Task DeleteById(int id);
    }
}
