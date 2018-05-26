
using Metro2018.DataLayer.Colonias;
using Metro2018.DataLayer.Estados;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Municipio
{
    [Table("delmun")]
    public class MunicipiosDao
    {
        [Key]
        public int IddelMun { get; set; }

        public int Idestado { get; set; }

        public string Nombre { get; set; }

        [InverseProperty("MunicipiosDao"), ForeignKey("Idestado")]
        public virtual EstadosDao EstadosDao { get; set; }

        [InverseProperty("MunicipiosDao")]
        public virtual ICollection<ColoniasDao> ColoniasDao { get; set; }
    }
}
