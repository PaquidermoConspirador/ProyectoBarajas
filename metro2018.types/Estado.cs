using System.ComponentModel.DataAnnotations;

namespace Metro2018.Types
{
    public class Estado
    {
        public int Idestado { get; set; }
        
        [MaxLength(150), Required]
        public string Nombre { get; set; }

        [MaxLength(3), Required]
        public string Corto { get; set; }
    }
}
