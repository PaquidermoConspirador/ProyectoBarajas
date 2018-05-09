using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer
{
    using DataInterfaces;
    using Departamentos;
    using System.Configuration;
    using System.Data.SqlClient;
    using Types;

    public class DepartamentosRepository : IDepartamentosRepository
    {
        private static string _connectionString;

        public DepartamentosRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Metro2018.ConnectionString"].ConnectionString;
        }

        Task IDepartamentosRepository.Create(Departamento newObj)
        {
            try
            {
                using (var dbContext = new DepartamentosDbContext(_connectionString))
                {
                    // Esta validación permite controlar si el nombre del producto no existe en la
                    // base de datos, ya que por regla de negocio, no deben existir nombres de productos
                    // iguales.
                    if (!dbContext.Departamentos.Any(d => d.nombre == newObj.Nombre))
                    {
                        DepartamentosDao newField = new DepartamentosDao()
                        {

                            nombre = newObj.Nombre,
                            activo = newObj.Activo
                        };
                        dbContext.Departamentos.Add(newField);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        throw new DuplicateItemException();
                    }
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

        async Task<IEnumerable<Departamento>> IDepartamentosRepository.ReadAll()
        {
            using (var dbContext = new DepartamentosDbContext(_connectionString))
            {
                var result = from obj in dbContext.Departamentos
                             select new Departamento
                             {
                                 Id = obj.iddepartamento,
                                 Nombre = obj.nombre,
                                 Activo = obj.activo
                             };

                var t = result.ToList();
                return t;
            }
        }

        async Task<Departamento> IDepartamentosRepository.ReadById(int id)
        {
            using (var dbContext = new DepartamentosDbContext(_connectionString))
            {
                var result = (from obj in dbContext.Departamentos
                              where obj.iddepartamento == id
                              select new Departamento
                              {
                                  Id = obj.iddepartamento,
                                  Nombre = obj.nombre,
                                  Activo = obj.activo
                              });

                return result.FirstOrDefault();
            }
        }
        Task IDepartamentosRepository.DeleteById(int id)
        {
            try
            {
                using (var dbContext = new DepartamentosDbContext(_connectionString))
                {
                    var field = dbContext.Departamentos.Find(id);
                    dbContext.Departamentos.Remove(field);
                    //dbContext.Entry(field).State = System.Data.Entity.EntityState.Deleted;
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

        Task IDepartamentosRepository.Update(Departamento updatedObj)
        {
            try
            {
                using (var dbContext = new DepartamentosDbContext(_connectionString))
                {
                    var field = dbContext.Departamentos.Find(updatedObj.Id);
                    field.nombre = updatedObj.Nombre;
                    field.activo = updatedObj.Activo;
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
