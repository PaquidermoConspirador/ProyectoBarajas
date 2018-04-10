using System.Data.Entity;

namespace Metro2018.DataLayer.Departamentos
{
    public class DepartamentosDbContext : DbContext
    {
        public DepartamentosDbContext(string connectionString)
            :base(connectionString)
        { }

        public virtual DbSet<DepartamentosDao> Departamentos { get; set; }
    }
}
