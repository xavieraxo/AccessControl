﻿using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.DTO_s.CentroCostoDTO
{
    public class CentroCostoDTO
    {
        public int? Id { get; set; }
        public bool Activo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }

        public virtual Procesamiento Procesamiento { get; set; }
    }
}
