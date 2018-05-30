using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.Types
{
    public class Proveedor
    {
        public int Idproveedor { get; set; }

        [MaxLength(150), Required]
        public string Nombre { get; set; }

        [MaxLength(150), Required]
        public string Direccion { get; set; }

        [Required]
        public int IdColPob { get; set; }

        [MaxLength(150), Required]
        public string Movil { get; set; }

        [MaxLength(150), Required]
        public string Email { get; set; }

        [Required]
        public bool Activo { get; set; }

        public string Colonia { get; set; }

    }
}
