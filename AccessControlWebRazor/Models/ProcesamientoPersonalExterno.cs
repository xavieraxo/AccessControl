using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlWebRazor.Models
{
    [Table("ProcesamientoPersonalExterno")]
    public class ProcesamientoPersonalExterno
    {
        [Key]
        public int Id { get; set; }
        public int PersonalExternoId { get; set; }
        public string DNI { get; set; }

        [DisplayName("Hora Ingreso")]
        public string HoraIngreso { get; set; }

        [DisplayName("Hora Egreso")]
        public string HoraEgreso { get; set; }

        [DisplayName("Total Horas")]
        public string TotalHoras { get; set; }
        public int Procesado { get; set; }

        [DisplayName("Estado Fichaje")]
        public string EstadoFichada { get; set; }

        [DisplayName("Centro de Costo")]
        public string CentroCostoDesc { get; set; }
        public int CentroCostoId { get; set; }
        public string Fecha { get; set; }

        public virtual CentroCosto CentroCostoModel { get; set; }
    }
}
