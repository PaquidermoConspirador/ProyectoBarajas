using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Colonias
{
    using Metro2018.DataLayer.Proveedores;
    using Metro2018.DataLayer.Municipio;
    using System.Collections.Generic;
    using Metro2018.DataLayer.Clientes;

    [Table("colpob")]
    public class ColoniasDao
    {
        public ColoniasDao()
        {
            //ClientesDao = new HashSet<ClientesDao>();
            ProveedoresDao = new HashSet<ProveedoresDao>();
        }

        [Key]
        public int IdColPob { get; set; }

        public int Iddelmun { get; set; }

        public string Nombre { get; set; }

        public int Cp { get; set; }


        //[InverseProperty("ColoniasDao"), ForeignKey("Iddelmun")]
        public virtual MunicipiosDao MunicipiosDao { get; set; }

        //[InverseProperty("ColoniasDao")]
        public virtual ICollection<ClientesDao> ClientesDao { get; set; }

        //[InverseProperty("ColoniasDao")]
        public virtual ICollection<ProveedoresDao> ProveedoresDao { get; set; }


    }
}
