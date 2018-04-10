using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Productos
{
    using Departamentos;
    using TiposProductos;

    [Table("producto")]
    public class ProductosDao
    {
        [Key]
        public int idproducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int? idtipoproducto { get; set; }
        public int? iddepartamento { get; set; }
        public bool activo { get; set; }
        [ForeignKey("idtipoproducto")]
        public virtual TiposProductosDao TipoProducto { get; set; }
        [ForeignKey("iddepartamento")]
        public virtual DepartamentosDao Departamento { get; set; }
    }
}
