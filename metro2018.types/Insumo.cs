using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.Types
{
    public class Insumo
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [MaxLength(100)]
        //[MinLength(10)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Descripción")]
        [MaxLength(150)]
        [MinLength(10)]
        public string Descripcion { get; set; }

        

    }
}
