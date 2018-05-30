using Metro2018.DataInterfaces;
using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metro2018.DataLayer
{
    using Metro2018.DataLayer.Empleados;
    using System.Configuration;
    using System.Data.SqlClient;

    public class EmpleadosRepository : IEmpleadosRepository
    {
        private static string _conectionString;

        public EmpleadosRepository()
        {
            _conectionString = ConfigurationManager.ConnectionStrings["Metro2018.ConnectionString"].ConnectionString;
        }

        Task IEmpleadosRepository.Create(Empleado newObj)
        {
            try
            {
                using (var dbContext = new EmpleadosDbContext(_conectionString))
                {

                    if (!dbContext.Empleados.Any(i => i.nombre == newObj.Nombre))
                    {
                        EmpleadosDao newField = new EmpleadosDao()
                        {
                            nombre = newObj.Nombre,
                            email = newObj.Email,
                            movil = newObj.Movil,
                            activo = newObj.Activo
                        };

                        dbContext.Empleados.Add(newField);
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
                    SqlException innexException = ex.InnerException as SqlException;
                    if (innexException.Number == 2627)
                    {
                        throw new DuplicateItemException();
                    }
                }
                throw;
            }
        }

        Task IEmpleadosRepository.DeleteById(int id)
        {
            try
            {
                using (var dbContext = new EmpleadosDbContext(_conectionString))
                {
                    var field = dbContext.Empleados.Find(id);
                    dbContext.Empleados.Remove(field);
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

        bool IEmpleadosRepository.EmpleadoIsAlreadyRegistered(string nombre)
        {
            throw new NotImplementedException();
        }

        void IEmpleadosRepository.NewEmpleado(Empleado empleado)
        {
            ((IEmpleadosRepository)this).Create(empleado);
        }

        async Task<IEnumerable<Empleado>> IEmpleadosRepository.ReadAll()
        {
            using (var dbContext = new EmpleadosDbContext(_conectionString))
            {
                var result = from obj in dbContext.Empleados
                             select new Empleado
                             {
                                 Id = obj.idEmpleado,
                                 Nombre = obj.nombre,
                                 Email = obj.email,
                                 Movil = obj.movil,
                                 Activo = obj.activo
                             };
                //var res = result.ToList();
                var t = result.ToList();
                return t;
            }
        }

        async Task<Empleado> IEmpleadosRepository.ReadById(int id)
        {
            using (var dbContext = new EmpleadosDbContext(_conectionString))
            {
                var result = from obj in dbContext.Empleados
                             where obj.idEmpleado == id
                             select new Empleado
                             {
                                 Id = obj.idEmpleado,
                                 Nombre = obj.nombre,
                                 Email = obj.email,
                                 Movil = obj.movil,
                                 Activo = obj.activo
                             };
                return result.FirstOrDefault();
            }
        }

        Task IEmpleadosRepository.Update(Empleado updatedObj)
        {
            try
            {
                using (var dbContext = new EmpleadosDbContext(_conectionString))
                {
                    var field = dbContext.Empleados.Find(updatedObj.Id);
                    field.nombre = updatedObj.Nombre;
                    field.email = updatedObj.Email;
                    field.movil = updatedObj.Movil;
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
