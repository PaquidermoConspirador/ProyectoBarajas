using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.Types
{
    public class Usuario
    {
        
        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Contraseña")]
        public string Contraseña { get; set; }
    
        [Required]
        [DisplayName("Id Privilegio")]
        public int IdPrivilegio { get; set; }

        [Required]
        [DisplayName("Correo")]
        [RegularExpression("[a-zA-Z0-9]*@[a-zA-Z0-9]*.[a-zA-Z]*")]
        [MaxLength(50)]
        public string Correo { get; set; }

        [Required]
        [DisplayName("Id de empleado")]
        public int IdEmpleado { get; set; }

        [Required]
        [DisplayName("Id de departamento")]
        public int IdDepartamento { get; set; }

        [Required]
        [DisplayName("Activo")]
        public bool Activo { get; set; }
    }
}
