using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessInterfaces
{
    using Types;

    public interface IInsumosProcessor
    {
        Task Create(Insumo newObj);
        Task<IEnumerable<Insumo>> ReadAll();
        Task<Insumo> ReadById(int id);
        Task Update(Insumo updatedObj);
    }
}
