using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Departamentos
{
    [Table("departamento")]
    public class DepartamentosDao
    {
        [Key]
        public int iddepartamento { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
    }
}
