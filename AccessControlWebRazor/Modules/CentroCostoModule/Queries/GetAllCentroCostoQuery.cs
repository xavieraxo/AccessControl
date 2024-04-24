using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CentroCostoModule.Queries
{
    public class GetAllCentroCostoQuery : IRequest<List<CentroCosto>>
    {
    }
}
