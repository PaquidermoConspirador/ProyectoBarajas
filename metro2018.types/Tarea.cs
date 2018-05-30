using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.Types
{
    public class Tarea
    {
        [Required]
        public int Idtarea { get; set; }

        [Required]
        public int Idtipotarea { get; set; }

        [Required]
        public DateTime Fechacreacion { get; set; }

        [Required]
        public int Creadopor { get; set; } = 2;

        [Required]
        public DateTime Fechaentrega { get; set; }

        [Required]
        public int Idprioridad { get; set; }


        public int? Idtareaprevia { get; set; } = null;

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int Idestatus { get; set; }
    }
}
