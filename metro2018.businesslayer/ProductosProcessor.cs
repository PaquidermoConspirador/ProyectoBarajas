using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.BusinessLayer
{
    using DataInterfaces;
    using DataLayer;
    using System.ComponentModel.DataAnnotations;
    using Types;

    public class ProductosProcessor
    {
        private readonly IProductosRepository _productosRepository;

        public ProductosProcessor(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }

        public void NewProduct(Producto producto)
        {
            var context = new ValidationContext(producto);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(producto, context, results, true);
            if(isValid == false)
            {
                throw new Exception("Han ocurrido varios errores de validación");
            }

            if (_productosRepository.ProductIsAlreadyRegistered(producto.Nombre))
                throw new Exception("El producto ya existe");

            _productosRepository.NewProduct(producto);
            
        }
    }
}
