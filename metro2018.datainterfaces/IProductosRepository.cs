﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataInterfaces
{
    using Types;

    public interface IProductosRepository
    {
        void NewProducto(Producto producto);
        bool ProductoIsAlreadyRegistered(string nombre);

        // CRUD - Create, Read, Update, Delete

        Task Create(Producto newObj);
        Task<IEnumerable<Producto>> ReadAll();
        Task<Producto> ReadById(int id);
        Task Update(Producto updatedObj);
        Task DeleteById(int id);
    }
}
