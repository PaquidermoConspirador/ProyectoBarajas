using Metro2018.DataLayer.Municipio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.DataLayer.Estados
{
    public class EstadosDao
    {
        [Key]
        public int Idestado { get; set; }

        public string Nombre { get; set; }

        public string Corto { get; set; }

        [InverseProperty("EstadosDao")]
        public virtual ICollection<MunicipiosDao> MunicipiosDao { get; set; }
    }
}
