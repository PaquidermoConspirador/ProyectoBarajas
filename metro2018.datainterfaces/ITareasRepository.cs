using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataInterfaces

    
{
    using Types;
    public interface ITareasRepository
    {
        void NewTarea(Tarea tarea);
        bool TareaIsAlreadyRegistered(string nombre);

        // CRUD - Create, Read, Update, Delete

        Task Create(Tarea newObj);
        Task<IEnumerable<Tarea>> ReadAll();
        Task<Tarea> ReadById(int id);
        Task Update(Tarea updatedObj);
        Task DeleteById(int id);
    }
}
