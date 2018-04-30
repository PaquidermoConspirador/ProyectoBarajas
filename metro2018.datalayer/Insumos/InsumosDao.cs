using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Insumos
{
    [Table("insumo")]
    public class InsumosDao
    {
        [Key]
        public int idinsumo;
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
