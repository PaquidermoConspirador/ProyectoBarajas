using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Metro2018.UnitTests
{
    using BusinessLayer;
    using Types;

    [TestClass]
    public class ProductosProcessorTest
    {
        [TestMethod]
        public void NewProductShouldSucced()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = "Papas papas",
                Descripcion = "Papas fritas",
                Precio = (decimal)10.50,
                Activo = true
            };

            var mockProductsRepository = new Mocks.MockProductsRepository();

            // Act
            var processor = new ProductosProcessor(mockProductsRepository);
            processor.NewProduct(producto);

            // Assert
            Assert.IsTrue(mockProductsRepository.IsProductAlreadyRegisteredInvoked, "Error al validar el nombre del producto");
            Assert.IsTrue(mockProductsRepository.NewProductInvoked, "No se registró el producto");
            Assert.IsFalse(mockProductsRepository.ProductIsAlreadyRegistered(producto.Nombre), "No se registró el producto");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewProductShouldFailWithProductAlreadyRegistered()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = "Papabritas",
                Descripcion = "Papas fritas",
                Precio = (decimal)10.50,
                Activo = true
            };

            var mockProductsRepository = new Mocks.MockProductsRepository();

            // Act
            var processor = new ProductosProcessor(mockProductsRepository);
            processor.NewProduct(producto);

            // Assert
            Assert.IsTrue(mockProductsRepository.IsProductAlreadyRegisteredInvoked, "Error al validar el nombre del producto");
            Assert.IsTrue(mockProductsRepository.NewProductInvoked, "No se registró el producto");
            Assert.IsTrue(mockProductsRepository.ProductIsAlreadyRegistered(producto.Nombre), "No se registró el producto");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewProductWithEmptyNameShouldFail()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = string.Empty,
                Descripcion = "Papas fritas",
                Precio = (decimal)10.50,
                Activo = true
            };
            // Act
            //var processor = new ProductosProcessor();
            //processor.NewProduct(producto);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewProductWithShortNameShouldFail()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = "Papas",
                Descripcion = "Papas fritas",
                Precio = (decimal)10.50,
                Activo = true
            };
            // Act
            //var processor = new ProductosProcessor();
            //processor.NewProduct(producto);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewProductWithLongNameShouldFail()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901",
                Descripcion = "Papas fritas",
                Precio = (decimal)10.50,
                Activo = true
            };
            // Act
            //var processor = new ProductosProcessor();
            //processor.NewProduct(producto);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewProductWithZeroPriceShouldFail()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = "12345678901",
                Descripcion = "Papas fritas",
                Precio = (decimal)0.0,
                Activo = true
            };
            // Act
            //var processor = new ProductosProcessor();
            //processor.NewProduct(producto);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewProductWithEmptyDescriptionShouldFail()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = "Papas fritas",
                Descripcion = string.Empty,
                Precio = (decimal)10.50,
                Activo = true
            };
            // Act
            //var processor = new ProductosProcessor();
            //processor.NewProduct(producto);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewProductWithShortDescriptionShouldFail()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = "Papas fritas",
                Descripcion = "Papas",
                Precio = (decimal)10.50,
                Activo = true
            };
            // Act
            //var processor = new ProductosProcessor();
            //processor.NewProduct(producto);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewProductWithLongDescriptionShouldFail()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = "Papas fritas",
                Descripcion = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901",
                Precio = (decimal)10.50,
                Activo = true
            };
            // Act
            //var processor = new ProductosProcessor();
            //processor.NewProduct(producto);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewProductWithNumbersInNameShouldFail()
        {
            // Arrange
            var producto = new Producto()
            {
                Id = 1,
                Nombre = "Papas fritas 123",
                Descripcion = "12345678901",
                Precio = (decimal)10.50,
                Activo = true
            };
            // Act
            //var processor = new ProductosProcessor();
            //processor.NewProduct(producto);

            // Assert

        }
    }
}
