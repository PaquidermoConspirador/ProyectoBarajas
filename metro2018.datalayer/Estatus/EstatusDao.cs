using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Estatus
{
    [Table("estatus")]
    public class EstatusDao
    {
        [Key]
        public int Idestatus { get; set; }

        public string Nombre { get; set; }
    }
}
