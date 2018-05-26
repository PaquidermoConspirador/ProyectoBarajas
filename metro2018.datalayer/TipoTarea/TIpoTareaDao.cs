using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.TipoTarea
{
    [Table("tipotarea")]
    public class TIpoTareaDao
    {
        [Key]
        public int Idtipotarea { get; set; }

        public string Nombre { get; set; }
    }
}
