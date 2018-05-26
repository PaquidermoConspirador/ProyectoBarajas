using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessInterfaces
{
    public interface ITareasProcessor
    {
        Task Create(Tarea newObj);
        Task<IEnumerable<Tarea>> ReadAll();
        Task<Tarea> ReadById(int id);
        Task Update(Tarea updatedObj);
        Task DeleteById(int id);
    }
}
