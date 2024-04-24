using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries
{
    public class GetAllProcesamientoDistincZeroQuery : IRequest<List<Procesamiento>>
    {

    }
}
