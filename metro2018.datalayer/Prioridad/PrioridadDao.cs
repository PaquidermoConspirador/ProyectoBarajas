using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Prioridad
{
    [Table("prioridad")]
    public class PrioridadDao
    {
        [Key]
        public int Idprioridad { get; set; }

        public string Nombre { get; set; }
        
    }
}
