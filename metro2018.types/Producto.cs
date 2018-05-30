using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.Types
{
    public class Producto
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [DisplayName("Precio")]
        public decimal Precio { get; set; }

        [Required]
        [DisplayName("ID tipo producto")]
        public int Idtipoproducto { get; set; }

        [Required]
        [DisplayName("Id del departamento")]
        public int Iddepartamento { get; set; }

        [Required]
        [DisplayName("Activo")]
        public bool Activo { get; set; }
    }
}
