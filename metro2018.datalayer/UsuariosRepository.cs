using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer
{
    using Metro2018.DataInterfaces;
    using Metro2018.DataLayer.Usuarios;
    using System.Configuration;
    using System.Data.SqlClient;
    using Types;

    public class UsuariosRepository : IUsuariosRepository
    {

        private static string _conectionString;

        public UsuariosRepository()
        {
            _conectionString = ConfigurationManager.ConnectionStrings["Metro2018.ConnectionString"].ConnectionString;
        }

        Task IUsuariosRepository.Create(Usuario newObj)
        {
            try
            {
                using (var dbContext = new UsuariosDbContext(_conectionString))
                {

                    if (!dbContext.Usuarios.Any(i => i.nombre == newObj.Nombre))
                    {
                        UsuariosDao newField = new UsuariosDao()
                        {                            
                            nombre = newObj.Nombre,
                            contrasena = newObj.Contraseña,
                            correo = newObj.Correo,
                            activo = newObj.Activo,
                            iddepartamento = newObj.IdDepartamento,
                            idempleado = newObj.IdEmpleado,
                            idprivilegio = newObj.IdPrivilegio
                        };

                        dbContext.Usuarios.Add(newField);
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

        Task IUsuariosRepository.DeleteById(int id)
        {
            try
            {
                using (var dbContext = new UsuariosDbContext(_conectionString))
                {
                    var field = dbContext.Usuarios.Find(id);
                    dbContext.Usuarios.Remove(field);
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

        void IUsuariosRepository.NewUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Usuario>> IUsuariosRepository.ReadAll()
        {
            using (var dbContext = new UsuariosDbContext(_conectionString))
            {
                var result = from obj in dbContext.Usuarios
                             select new Usuario
                             {
                                 Id = obj.idusuario,
                                 Nombre = obj.nombre,
                                 Contraseña = obj.contrasena,
                                 Correo = obj.correo,
                                 Activo = obj.activo,
                                 IdDepartamento = obj.iddepartamento,
                                 IdEmpleado = obj.idempleado,
                                 IdPrivilegio = obj.idprivilegio
                             };
                //var res = result.ToList();
                var t = result.ToList();
                return t;
            }
        }

        async Task<Usuario> IUsuariosRepository.ReadById(int id)
        {
            using (var dbContext = new UsuariosDbContext(_conectionString))
            {
                var result = from obj in dbContext.Usuarios
                            where obj.idusuario == id
                            select new Usuario
                            {
                                Id = obj.idusuario,
                                Nombre = obj.nombre,
                                Contraseña = obj.contrasena,
                                Correo = obj.correo,
                                Activo = obj.activo,
                                IdDepartamento = obj.iddepartamento,
                                IdEmpleado = obj.idempleado,
                                IdPrivilegio = obj.idprivilegio
                            };
                return result.FirstOrDefault();
            }
        }

        Task IUsuariosRepository.Update(Usuario updatedObj)
        {
            try
            {
                using (var dbContext = new UsuariosDbContext(_conectionString))
                {
                    var field = dbContext.Usuarios.Find(updatedObj.Id);
                    field.nombre = updatedObj.Nombre;
                    field.contrasena = updatedObj.Contraseña;
                    field.correo = updatedObj.Correo;
                    field.activo = updatedObj.Activo;
                    field.idprivilegio = updatedObj.IdPrivilegio;
                    field.iddepartamento = updatedObj.IdDepartamento;
                    field.idempleado = updatedObj.IdEmpleado;
                    
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

        bool IUsuariosRepository.UsuarioIsAlreadyRegistered(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
