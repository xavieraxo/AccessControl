using AccessControlWebRazor.Modules.ApiHikVisionModule.Query;
using AccessControlWebRazor.Modules.ApiHikVisionModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ApiHikVisionModule.Handler;

public class SendVehiclesToAPIQueryHandler : IRequestHandler<SendVehiclesToAPIQuery, bool>
{
    private readonly IHikVisionService _hikVisionService;

    public SendVehiclesToAPIQueryHandler(IHikVisionService hikVisionService)
    {
        _hikVisionService = hikVisionService;
    }
    public async Task<bool> Handle(SendVehiclesToAPIQuery request, CancellationToken cancellationToken)
    {
        var result = _hikVisionService.SendWhiteListToHikVisionCamera(request.VehiculosProdeng, request.VehiculosExternos);
        return result.IsCompleted;
    }
}
