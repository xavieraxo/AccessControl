using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Queries
{
    public class GetAllProcessExternalQuery : IRequest<List<ProcesamientoPersonalExterno>>
    {
    }
}
