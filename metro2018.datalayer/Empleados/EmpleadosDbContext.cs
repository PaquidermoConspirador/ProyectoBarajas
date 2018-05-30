using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Empleados
{
    public class EmpleadosDbContext : DbContext
    {
        public EmpleadosDbContext(string conectionString)
            : base(conectionString)
        { }

        public virtual DbSet<EmpleadosDao> Empleados { get; set; }
    }
}
