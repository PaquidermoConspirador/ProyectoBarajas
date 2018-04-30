using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer
{
    using DataInterfaces;
    using Metro2018.Types;
    using System.Configuration;

    public class InsumosRepository : IInsumoRepository
    {

        private static string _conectionString;

        public InsumosRepository()
        {
            _conectionString = ConfigurationManager.ConnectionStrings["Metro2018.ConnectionString"].ConnectionString;
        }

        Task IInsumoRepository.Create(Insumo newObj)
        {
            throw new NotImplementedException();
        }

        bool IInsumoRepository.InsumoIsAlreadyRegistered(string nombre)
        {
            throw new NotImplementedException();
        }

        void IInsumoRepository.NewInsumo(Insumo insumo)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Insumo>> IInsumoRepository.ReadAll()
        {
            throw new NotImplementedException();
        }

        Task<Insumo> IInsumoRepository.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        Task IInsumoRepository.Update(Insumo updatedObj)
        {
            throw new NotImplementedException();
        }
    }
}
