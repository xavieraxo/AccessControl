using AccessControlWebRazor.Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccessControlWebRazor.Models
{
    public class LecturasGaritaLog
    {
        public LecturasGaritaLog()
        {
            Apellido = string.Empty;
            Nombre = string.Empty;
            Genero = string.Empty;
            TipoEjemplar = string.Empty;
            Observaciones = string.Empty;
            EstadoLectura = string.Empty;  
            DNI = string.Empty;
            FechaNacimiento = string.Empty; 
            FechaVencimiento = string.Empty;    
            NumeroExtraCuit = string.Empty;   
            
        }
        public int Id { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public string? DNI { get; set; }
        
        [DisplayName("Ejemplar")]
        public string? TipoEjemplar { get; set; }

        [DisplayName("Nacimiento")]
        public string? FechaNacimiento { get; set; }

        [DisplayName("Vencimiento")]
        public string? FechaVencimiento { get; set; }

        [DisplayName("Cuit")]
        public string? NumeroExtraCuit { get; set; }
        public string? Observaciones { get; set; }

        [DisplayName("Estado Lectura")]
        public string? EstadoLectura { get; set; }

        [DisplayName("Fecha Lectura")]
        public DateTime? FechaLectura { get; set;}
        public int Procesado { get; set; }


    }
}
