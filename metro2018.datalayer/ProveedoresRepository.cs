using Metro2018.DataInterfaces;
using Metro2018.DataLayer.Proveedores;
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
    public class ProveedoresRepository : IProveedoresRepository
    {
        private static string _conectionString;

        public ProveedoresRepository()
        {
            _conectionString = ConfigurationManager.ConnectionStrings["Metro2018.ConnectionString"].ConnectionString;
        }


        Task IProveedoresRepository.Create(Proveedor newObj)
        {
            try
            {
                using (var dbContext = new ProveedoresDbContext(_conectionString))
                {

                    if (!dbContext.Proveedores.Any(i => i.Nombre == newObj.Nombre))
                    {
                        ProveedoresDao newField = new ProveedoresDao()
                        {
                            Nombre = newObj.Nombre,
                            Activo = newObj.Activo,
                            IdColPob = newObj.IdColPob,
                            Direccion = newObj.Direccion,
                            Email = newObj.Email,
                            Movil = newObj.Movil
                        };

                        dbContext.Proveedores.Add(newField);
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

        bool IProveedoresRepository.ProveedorIsAlreadyRegistered(string nombre)
        {
            throw new NotImplementedException();
        }

        void IProveedoresRepository.NewProveedor(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Proveedor>> IProveedoresRepository.ReadAll()
        {
            using (var dbContext = new ProveedoresDbContext(_conectionString))
            {
                var result = from obj in dbContext.Proveedores
                             select new Proveedor
                             {
                                 Idproveedor = obj.Idproveedor,
                                 Nombre = obj.Nombre,
                                 Activo = obj.Activo,
                                 IdColPob = obj.IdColPob,
                                 Direccion = obj.Direccion,
                                 Email = obj.Email,
                                 Movil = obj.Movil,
                                 Colonia = obj.Colonias.Nombre
                             };
                //var res = result.ToList();
                var t = result.ToList();
                return t;
            }
        }

        async Task<Proveedor> IProveedoresRepository.ReadById(int id)
        {
            using (var dbContext = new ProveedoresDbContext(_conectionString))
            {
                var result = from obj in dbContext.Proveedores
                             where obj.Idproveedor == id
                             select new Proveedor
                             {
                                 Nombre = obj.Nombre,
                                 Activo = obj.Activo,
                                 IdColPob = obj.IdColPob,
                                 Direccion = obj.Direccion,
                                 Email = obj.Email,
                                 Movil = obj.Movil
                             };
                return result.FirstOrDefault();
            }
        }

        Task IProveedoresRepository.Update(Proveedor updatedObj)
        {
            try
            {
                using (var dbContext = new ProveedoresDbContext(_conectionString))
                {
                    var field = dbContext.Proveedores.Find(updatedObj.Idproveedor);
                    field.Nombre = updatedObj.Nombre;
                    field.Activo = updatedObj.Activo;
                    field.IdColPob = updatedObj.IdColPob;
                    field.Direccion = updatedObj.Direccion;
                    field.Email = updatedObj.Email;
                    field.Movil = updatedObj.Movil;

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

        Task IProveedoresRepository.DeleteById(int id)
        {
            try
            {
                using (var dbContext = new ProveedoresDbContext(_conectionString))
                {
                    var field = dbContext.Proveedores.Find(id);
                    dbContext.Proveedores.Remove(field);
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

        public Task<Proveedor> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Proveedor updatedObj)
        {
            throw new NotImplementedException();
        }
    }
}
