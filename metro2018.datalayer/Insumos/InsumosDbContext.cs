using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Insumos
{
    
    public class InsumosDbContext : DbContext
    {
        public InsumosDbContext(string conectionString)
            : base(conectionString)
        { }

        public virtual DbSet<InsumosDao> Insumos { get; set; }
    }
}
