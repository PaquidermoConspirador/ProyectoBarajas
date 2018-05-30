using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Clientes
{
    using Metro2018.DataLayer.Colonias;

    [Table("cliente")]
    public class ClientesDao
    {
        [Key]
        public int Idcliente { get; set; }

        public string Nombre { get; set; }
        
        public string RFC { get; set; }

        public string Direccion { get; set; }

        public int IdColPob { get; set; }

        public string Movil { get; set; }

        public string Email { get; set; }

        public bool Activo { get; set; }

        //[InverseProperty("ClientesDao"), ForeignKey("IdColPob")]
        public virtual ColoniasDao Colonias { get; set; }
    }
}
