using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer
{
    using DataInterfaces;
    using Metro2018.DataLayer.Insumos;
    using Metro2018.Types;
    using System.Configuration;
    using System.Data.SqlClient;

    public class InsumosRepository : IInsumoRepository
    {

        private static string _conectionString;

        public InsumosRepository()
        {
            _conectionString = ConfigurationManager.ConnectionStrings["Metro2018.ConnectionString"].ConnectionString;
        }

        Task IInsumoRepository.Create(Insumo newObj)
        {
            try
            {
                using(var dbContext = new InsumosDbContext(_conectionString))
                {

                    if(!dbContext.Insumos.Any(i => i.nombre == newObj.Nombre))
                    {
                        InsumosDao newField = new InsumosDao()
                        {
                            nombre = newObj.Nombre,
                            descripcion = newObj.Descripcion
                        };

                        dbContext.Insumos.Add(newField);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        throw new DuplicateItemException();
                    }
                }
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                if(ex.InnerException.GetType() == typeof(SqlException))
                {
                    SqlException innexException = ex.InnerException as SqlException;
                    if (innexException.Number == 2627)
                    {
                        throw new DuplicateItemException();
                    }
                }
                throw;
            }
        }

        bool IInsumoRepository.InsumoIsAlreadyRegistered(string nombre)
        {
            throw new NotImplementedException();
        }

        void IInsumoRepository.NewInsumo(Insumo insumo)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Insumo>> IInsumoRepository.ReadAll()
        {
            using (var dbContext = new InsumosDbContext(_conectionString))
            {
                var result = from obj in dbContext.Insumos
                             select new Insumo
                             {
                                 Id = obj.idinsumo,
                                 Nombre = obj.nombre,
                                 Descripcion = obj.descripcion
                             };
                //var res = result.ToList();
                var t = result.ToList();
                return t;
            }
        }

        async Task<Insumo> IInsumoRepository.ReadById(int id)
        {
            using (var dbContext = new InsumosDbContext(_conectionString))
            {
                var result = from obj in dbContext.Insumos
                             where obj.idinsumo == id
                             select new Insumo
                             {
                                 Id = obj.idinsumo,
                                 Nombre = obj.nombre,
                                 Descripcion = obj.descripcion
                             };
                return result.FirstOrDefault();
            }
        }

        Task IInsumoRepository.Update(Insumo updatedObj)
        {
            try
            {
                using (var dbContext = new InsumosDbContext(_conectionString))
                {
                    var field = dbContext.Insumos.Find(updatedObj.Id);
                    field.nombre = updatedObj.Nombre;
                    field.descripcion = updatedObj.Descripcion;
                    dbContext.Entry(field).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                }
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.GetType() == typeof(SqlException))
                {
                    SqlException innerException = ex.InnerException as SqlException;
                    if (innerException.Number == 2627)
                    {
                        throw new DuplicateItemException();
                    }
                }
                throw;
            }
        }
    }
}
