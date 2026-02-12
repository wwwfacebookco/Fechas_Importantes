using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fechas_Importantes.Models
{
    [Table("FechasEspeciales")]
    public class FechaEspecial
    {
        [Key]
        [Column("id_fecha")]   // nombre real en la BD
        public int Id_Fecha { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("nota")]
        public string Nota { get; set; }
    }
}
