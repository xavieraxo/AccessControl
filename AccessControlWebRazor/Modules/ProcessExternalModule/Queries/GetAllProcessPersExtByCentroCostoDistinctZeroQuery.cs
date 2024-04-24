using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Queries
{
    public class GetAllProcessPersExtByCentroCostoDistinctZeroQuery : IRequest<List<ProcesamientoPersonalExterno>>
    {
    }
}
