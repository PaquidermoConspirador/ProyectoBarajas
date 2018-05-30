using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer
{
    using Metro2018.DataInterfaces;
    using Metro2018.DataLayer.Productos;
    using System.Configuration;
    using System.Data.SqlClient;
    using Types;

    public class ProductosRepository : IProductosRepository
    {

        private static string _conectionString;

        public ProductosRepository()
        {
            _conectionString = ConfigurationManager.ConnectionStrings["Metro2018.ConnectionString"].ConnectionString;
        }

        Task IProductosRepository.Create(Producto newObj)
        {
            try
            {
                using (var dbContext = new ProductosDbContext(_conectionString))
                {

                    if (!dbContext.Productos.Any(i => i.Nombre == newObj.Nombre))
                    {
                        ProductosDao newField = new ProductosDao()
                        {
                            Nombre = newObj.Nombre,
                            Descripcion = newObj.Descripcion,
                            idtipoproducto = newObj.Idtipoproducto,
                            Precio = newObj.Precio,
                            iddepartamento = newObj.Iddepartamento,
                            Activo = newObj.Activo,
                        };

                        dbContext.Productos.Add(newField);
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

        Task IProductosRepository.DeleteById(int id)
        {
            try
            {
                using (var dbContext = new ProductosDbContext(_conectionString))
                {
                    var field = dbContext.Productos.Find(id);
                    dbContext.Productos.Remove(field);
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

        void IProductosRepository.NewProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Producto>> IProductosRepository.ReadAll()
        {
            using (var dbContext = new ProductosDbContext(_conectionString))
            {
                var result = from obj in dbContext.Productos
                             select new Producto
                             {
                                 Id = obj.Idproducto,
                                 Nombre = obj.Nombre,
                                 Descripcion = obj.Descripcion,
                                 Activo = obj.Activo,
                                 Iddepartamento = obj.iddepartamento,
                                 Idtipoproducto = obj.idtipoproducto,
                                 Precio = obj.Precio                              
                             };
                //var res = result.ToList();
                var t = result.ToList();
                return t;
            }
        }

        async Task<Producto> IProductosRepository.ReadById(int id)
        {
            using (var dbContext = new ProductosDbContext(_conectionString))
            {
                var result = from obj in dbContext.Productos
                             where obj.Idproducto == id
                             select new Producto
                             {
                                 Id = obj.Idproducto,
                                 Nombre = obj.Nombre,
                                 Descripcion = obj.Descripcion,
                                 Activo = obj.Activo,
                                 Iddepartamento = obj.iddepartamento,
                                 Idtipoproducto = obj.idtipoproducto,
                                 Precio = obj.Precio
                             };
                return result.FirstOrDefault();
            }
        }

        Task IProductosRepository.Update(Producto updatedObj)
        {
            try
            {
                using (var dbContext = new ProductosDbContext(_conectionString))
                {
                    var field = dbContext.Productos.Find(updatedObj.Id);
                    field.Nombre = updatedObj.Nombre;
                    field.Descripcion= updatedObj.Descripcion;
                    field.Activo = updatedObj.Activo;
                    field.idtipoproducto = updatedObj.Idtipoproducto;
                    field.iddepartamento = updatedObj.Iddepartamento;
                    field.Precio = updatedObj.Precio;
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

        bool IProductosRepository.ProductoIsAlreadyRegistered(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
