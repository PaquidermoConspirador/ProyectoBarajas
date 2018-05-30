using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Tareas
{
    public class TareasDbContext : DbContext
    {
        public TareasDbContext(string conectionString)
            : base(conectionString)
        { }

        public virtual DbSet<TareasDao> Tareas { get; set; }
    }
}
