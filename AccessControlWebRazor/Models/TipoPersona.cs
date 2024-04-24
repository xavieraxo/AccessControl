using AccessControlWebRazor.Infraestructura.Repositories;

namespace AccessControlWebRazor.Models
{
    public class TipoPersona
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static implicit operator TipoPersona(TipoPersonasRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
