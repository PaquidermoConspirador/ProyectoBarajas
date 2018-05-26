using Metro2018.DataLayer.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Proveedores
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(string conectionString)
            : base(conectionString)
        { }

        public virtual DbSet<ClientesDao> Clientes { get; set; }
    }
}
