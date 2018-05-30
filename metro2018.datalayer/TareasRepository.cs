using Metro2018.DataInterfaces;
using Metro2018.DataLayer.Tareas;
using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer
{
    public class TareasRepository : ITareasRepository
    {
        private static string _conectionString;

        public TareasRepository()
        {
            _conectionString = ConfigurationManager.ConnectionStrings["Metro2018.ConnectionString"].ConnectionString;
        }


        Task ITareasRepository.Create(Tarea newObj)
        {
            try
            {
                using (var dbContext = new TareasDbContext(_conectionString))
                {

                    if (!dbContext.Tareas.Any(i => i.Descripcion == newObj.Descripcion))
                    {
                        TareasDao newField = new TareasDao()
                        {                         
                          
                            Idtipotarea = newObj.Idtipotarea,
                            Fechacreacion = newObj.Fechacreacion,
                            Creadopor = newObj.Creadopor,
                            Fechaentrega = newObj.Fechaentrega,
                            Idprioridad = newObj.Idprioridad, 
                            Idtareaprevia = newObj.Idtareaprevia,
                            Descripcion = newObj.Descripcion,
                            Idestatus = newObj.Idestatus

                        };

                        dbContext.Tareas.Add(newField);
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

        bool ITareasRepository.TareaIsAlreadyRegistered(string Descripcion)
        {
            throw new NotImplementedException();
        }

        void ITareasRepository.NewTarea(Tarea tarea)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Tarea>> ITareasRepository.ReadAll()
        {
            using (var dbContext = new TareasDbContext(_conectionString))
            {
                var result = from newObj in dbContext.Tareas
                             select new Tarea
                             {
                                 Idtarea = newObj.Idtarea,
                                 Idtipotarea = newObj.Idtipotarea,
                                 Fechacreacion = newObj.Fechacreacion,
                                 Creadopor = newObj.Creadopor,
                                 Fechaentrega = newObj.Fechaentrega,
                                 Idprioridad = newObj.Idprioridad,
                                 Idtareaprevia = newObj.Idtareaprevia,
                                 Descripcion = newObj.Descripcion,
                                 Idestatus = newObj.Idestatus
                             };
                //var res = result.ToList();
                var t = result.ToList();
                return t;
            }
        }

        async Task<Tarea> ITareasRepository.ReadById(int id)
        {
            using (var dbContext = new TareasDbContext(_conectionString))
            {
                var result = from newObj in dbContext.Tareas
                             where newObj.Idtarea == id
                             select new Tarea
                             {
                                 Idtarea = newObj.Idtarea,
                                 Idtipotarea = newObj.Idtipotarea,
                                 Fechacreacion = newObj.Fechacreacion,
                                 Creadopor = newObj.Creadopor,
                                 Fechaentrega = newObj.Fechaentrega,
                                 Idprioridad = newObj.Idprioridad,
                                 Idtareaprevia = newObj.Idtareaprevia,
                                 Descripcion = newObj.Descripcion,
                                 Idestatus = newObj.Idestatus
                             };
                return result.FirstOrDefault();
            }
        }

        Task ITareasRepository.Update(Tarea updatedObj)
        {
            try
            {
                using (var dbContext = new TareasDbContext(_conectionString))
                {
                    var field = dbContext.Tareas.Find(updatedObj.Idtarea);

                    field.Idtarea = updatedObj.Idtarea;
                    field.Idtipotarea = updatedObj.Idtipotarea;
                    field.Fechacreacion = updatedObj.Fechacreacion;
                    field.Creadopor = updatedObj.Creadopor;
                    field.Fechaentrega = updatedObj.Fechaentrega;
                    field.Idprioridad = updatedObj.Idprioridad;
                    field.Idtareaprevia = updatedObj.Idtareaprevia;
                    field.Descripcion = updatedObj.Descripcion;
                    field.Idestatus = updatedObj.Idestatus;
                    
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

        Task ITareasRepository.DeleteById(int id)
        {
            try
            {
                using (var dbContext = new TareasDbContext(_conectionString))
                {
                    var field = dbContext.Tareas.Find(id);
                    dbContext.Tareas.Remove(field);
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

        public Task<Tarea> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Tarea updatedObj)
        {
            throw new NotImplementedException();
        }
    }
}
