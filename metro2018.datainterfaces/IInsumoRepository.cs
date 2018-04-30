using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataInterfaces
{
    using Types;

    public interface IInsumoRepository
    {
        void NewInsumo(Insumo insumo);
        bool InsumoIsAlreadyRegistered(string nombre);

        // CRUD - Create, Read, Update, Delete

        Task Create(Insumo newObj);
        Task<IEnumerable<Insumo>> ReadAll();
        Task<Insumo> ReadById(int id);
        Task Update(Insumo updatedObj);
    }
}
