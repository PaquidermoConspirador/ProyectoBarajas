
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Productos
{
 

    [Table("producto")]
    public class ProductosDao
    {
        [Key]
        public int Idproducto { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool Activo { get; set; }

        //No llaves foraneas proqeu no esta completo el programa
        public int idtipoproducto { get; set; }
        public int iddepartamento { get; set; }
    }
}
