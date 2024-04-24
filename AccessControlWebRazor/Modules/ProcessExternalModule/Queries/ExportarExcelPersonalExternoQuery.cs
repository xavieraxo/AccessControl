using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Queries
{
    public class ExportarExcelPersonalExternoQuery : IRequest<byte[]>
    {
        public List<ProcesamientoPersonalExterno> PersonalExternos { get; set; }

        public ExportarExcelPersonalExternoQuery(List<ProcesamientoPersonalExterno> procesamientoPersonals)
        {
            PersonalExternos = procesamientoPersonals;
        }
    }
}
