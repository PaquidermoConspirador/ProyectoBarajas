using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.Types
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [MaxLength(100)]
        [RegularExpression("[a-zA-Z]*")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("E-Mail")]
        [MaxLength(150)]
        [RegularExpression("[a-zA-Z0-9]*@[a-zA-Z]*.com")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Movil")]
        [RegularExpression("[0-9]*")]
        public string Movil { get; set; }

        [Required]
        [DisplayName("Activo")]
        public bool Activo { get; set; }
    }
}
