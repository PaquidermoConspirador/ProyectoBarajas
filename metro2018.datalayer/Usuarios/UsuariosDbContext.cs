using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Usuarios
{
    class UsuariosDbContext : DbContext
    {
        public UsuariosDbContext(string conectionString)
            : base(conectionString)
        { }

        public virtual DbSet<UsuariosDao> Usuarios { get; set; }
    }
}
