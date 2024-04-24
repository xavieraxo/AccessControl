namespace AccessControlWebRazor.Models
{
    public class CentroCosto
    {
        //[Key]
        public int ID { get; set; }
        public bool Activo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }

       // public Procesamiento Procesamiento { get; set; }

       // public ProcesamientoPersonalExterno ProcesamientoPersonalExterno { get; set; }
    }
}
