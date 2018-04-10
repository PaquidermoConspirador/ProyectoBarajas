using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Metro2018.Types
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [MaxLength(100)]
        [MinLength(10)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Descripción")]
        [MaxLength(100)]
        [MinLength(10)]
        public string Descripcion { get; set; }

        [Required]
        [DisplayName("Precio")]
        [DataType(DataType.Currency)]
        [Range(0.01, 999999.99, ErrorMessage = "Error")]
        public decimal Precio { get; set; }

        [Required]
        [DisplayName("Activo")]
        public bool Activo { get; set; }
    }
}
