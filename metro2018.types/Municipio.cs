using System.ComponentModel.DataAnnotations;

namespace Metro2018.Types
{
    public class Municipio
    {
        public int IddelMun { get; set; }

        [Required]
        public int Idestado { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }
    }
}
