using System.ComponentModel;

namespace AccessControlWebRazor.Models
{
    public class Procesamiento
    {   
        //[Key]
        public int Id { get; set; }
        public string? Legajo { get; set; }
        public string? DNI { get; set; }
        [DisplayName("Hora Ingreso")]
        public string? HoraIngreso { get; set; }

        [DisplayName("Hora Egreso")]
        public string? HoraEgreso { get; set; }

        [DisplayName("Total Horas")]
        public string? TotalHoras { get; set; }
        public bool? Procesado { get; set; }
        public string? ProcedenciaEmpleado { get; set; }

        [DisplayName("Estado Fichaje")]
        public string? EstadoFichada { get; set; }
        [DisplayName("Centro de Costo")]
        public string? CentroCostoDesc { get; set; }

        public string Fecha { get; set; }

        public int CentroCosto { get; set; }

        
        //Propiedad de Navegacion
        public virtual CentroCosto CentroCostoModel { get; set; }
    }
}
