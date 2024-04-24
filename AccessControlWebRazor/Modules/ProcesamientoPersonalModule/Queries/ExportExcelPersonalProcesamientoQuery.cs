using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries
{
    public class ExportExcelPersonalProcesamientoQuery : IRequest<byte[]>
    {
        public List<Procesamiento> Procesamientos { get; set; }

        public ExportExcelPersonalProcesamientoQuery(List<Procesamiento> procesamiento)
        {
            Procesamientos = procesamiento;
        }
    }
}
