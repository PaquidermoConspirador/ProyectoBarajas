
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Proveedores
{
    using Metro2018.DataLayer.Colonias;

    [Table("proveedor")]
    public class ProveedoresDao
    {
        [Key]
        public int Idproveedor { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public int IdColPob { get; set; }

        public string Movil { get; set; }

        public string Email { get; set; }

        public bool Activo { get; set; }

        //[InverseProperty("ProveedoresDao"), ForeignKey("IdColPob")]
        public virtual ColoniasDao Colonias { get; set; }
    }
}
