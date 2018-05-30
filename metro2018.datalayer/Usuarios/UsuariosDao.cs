using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Usuarios
{
    [Table("usuario")]
    public class UsuariosDao
    {
        [Key]
        public int idusuario { get; set; }

        public string nombre { get; set; }

        public string contrasena { get; set; }

        public string correo { get; set; }

        public int idprivilegio { get; set; }

        public int idempleado { get; set; }

        public int iddepartamento { get; set; }

        public bool activo { get; set; }

    }
}
