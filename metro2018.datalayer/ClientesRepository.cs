using Metro2018.DataInterfaces;
using Metro2018.DataLayer.Clientes;
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
    public class ClientesRepository : IClientesRepository
    {
        private static string _conectionString;

        public ClientesRepository()
        {
            _conectionString = ConfigurationManager.ConnectionStrings["Metro2018.ConnectionString"].ConnectionString;
        }


        Task IClientesRepository.Create(Cliente newObj)
        {
            try
            {
                using (var dbContext = new ClientesDbContext(_conectionString))
                {

                    if (!dbContext.Clientes.Any(i => i.Nombre == newObj.Nombre))
                    {
                        ClientesDao newField = new ClientesDao()
                        {
                            Nombre = newObj.Nombre,
                            Activo = newObj.Activo,
                            IdColPob = newObj.IdColPob,
                            Direccion = newObj.Direccion,
                            Email = newObj.Email,
                            Movil = newObj.Movil,
                            RFC = newObj.RFC
                        };

                        dbContext.Clientes.Add(newField);
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

        bool IClientesRepository.ClienteIsAlreadyRegistered(string nombre)
        {
            throw new NotImplementedException();
        }

        void IClientesRepository.NewCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Cliente>> IClientesRepository.ReadAll()
        {
            using (var dbContext = new ClientesDbContext(_conectionString))
            {
                var result = from obj in dbContext.Clientes
                             select new Cliente
                             {
                                 Idcliente = obj.Idcliente,
                                 Nombre = obj.Nombre,
                                 Activo = obj.Activo,
                                 IdColPob = obj.IdColPob,
                                 Direccion = obj.Direccion,
                                 Email = obj.Email,
                                 Movil = obj.Movil,
                                 RFC = obj.RFC,
                                 Colonia = obj.Colonias.Nombre
                             };
                //var res = result.ToList();
                var t = result.ToList();
                return t;
            }
        }

        async Task<Cliente> IClientesRepository.ReadById(int id)
        {
            using (var dbContext = new ClientesDbContext(_conectionString))
            {
                var result = from obj in dbContext.Clientes
                             where obj.Idcliente == id
                             select new Cliente
                             {                                 
                                 Nombre = obj.Nombre,
                                 Activo = obj.Activo,
                                 IdColPob = obj.IdColPob,
                                 Direccion = obj.Direccion,
                                 Email = obj.Email,
                                 Movil = obj.Movil,
                                 RFC = obj.RFC
                             };
                return result.FirstOrDefault();
            }
        }

        Task IClientesRepository.Update(Cliente updatedObj)
        {
            try
            {
                using (var dbContext = new ClientesDbContext(_conectionString))
                {
                    var field = dbContext.Clientes.Find(updatedObj.Idcliente);
                    field.Nombre = updatedObj.Nombre;
                    field.Activo = updatedObj.Activo;
                    field.IdColPob = updatedObj.IdColPob;
                    field.Direccion = updatedObj.Direccion;
                    field.Email = updatedObj.Email;
                    field.Movil = updatedObj.Movil;
                    field.RFC = updatedObj.RFC;

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

        Task IClientesRepository.DeleteById(int id)
        {
            try
            {
                using (var dbContext = new ClientesDbContext(_conectionString))
                {
                    var field = dbContext.Clientes.Find(id);
                    dbContext.Clientes.Remove(field);
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
    }
}
