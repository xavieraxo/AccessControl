using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlWebRazor.Models
{
    [Table("ProcesamientoVehiculoExterno")]
    public class ProcesamientoVehiculoExterno
    {
        [Key]
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public string Dominio { get; set; }

        [DisplayName("Hora Ingreso")]
        public string HoraIngreso { get; set; }

        [DisplayName("Hora Egreso")]
        public string HoraEgreso { get; set; }

        [DisplayName("Total Horas")]
        public string TotalHoras { get; set; }
        public int Procesado { get; set; }

        [DisplayName("Estado Fichaje")]
        public string? EstadoFichado { get; set; }

        [DisplayName("Centro de Costo")]
        public string CentroCostoDesc { get; set; }
        public string Fecha { get; set; }
        public int CentroCostoID { get; set; }


    }
}
