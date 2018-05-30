using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Productos
{
    public class ProductosDbContext : DbContext
    {
        public ProductosDbContext(string conectionString)
            : base(conectionString)
        { }

        public virtual DbSet<ProductosDao> Productos { get; set; }
    }
}
