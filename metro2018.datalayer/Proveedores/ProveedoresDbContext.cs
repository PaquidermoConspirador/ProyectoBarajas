using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Proveedores
{
    public class ProveedoresDbContext : DbContext
    {
        public ProveedoresDbContext(string conectionString)
            : base(conectionString)
        { }

        public virtual DbSet<ProveedoresDao> Proveedores { get; set; }
    }
}
