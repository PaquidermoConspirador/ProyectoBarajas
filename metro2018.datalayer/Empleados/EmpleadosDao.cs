using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Empleados
{
    [Table("empleado")]
    public class EmpleadosDao
    {
        [Key]
        public int idEmpleado { get; set; }

        public string nombre { get; set; }
        public string email { get; set; }
        public string movil { get; set; }
        public bool activo { get; set; }
        
    }
}
