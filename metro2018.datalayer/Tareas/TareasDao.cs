

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2018.DataLayer.Tareas
{
    [Table("tarea")]
    public class TareasDao
    {
        [Key]
        public int Idtarea { get; set; }

        public int Idtipotarea { get; set; }

        public DateTime Fechacreacion { get; set; }

        public int Creadopor { get; set; }

        public DateTime Fechaentrega { get; set; }

        public int Idprioridad { get; set; }

        public int? Idtareaprevia { get; set; }

        public string Descripcion { get; set; }

        public int Idestatus { get; set; }
    }
}
