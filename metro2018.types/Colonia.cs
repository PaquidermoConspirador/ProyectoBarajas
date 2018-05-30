using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.Types
{
    public class Colonia
    {
        public int Idcolpob { get; set; }

        [Required]
        public int Iddelmun { get; set; }

        [MaxLength(150),Required]
        public string Nombre { get; set; }

        [Required]
        public int Cp { get; set; }

    }
}
