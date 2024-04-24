using AccessControlWebRazor.DTO_s.CertronicDTO_s;
using AccessControlWebRazor.DTO_s.CreatePersonalDTO;
using AccessControlWebRazor.DTO_s.CreateVehiculoDTO;
using AccessControlWebRazor.DTO_s.PersonalDTO_s;
using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.PersonalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Command;
using AccessControlWebRazor.Modules.ProcessExternalModule.Command;
using AccessControlWebRazor.Modules.VehiculosModule.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlWebRazor.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValidationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreatePersonal")]
        public async Task<IActionResult> CreatePersonal(CreatePersonalDTO personalDto)//(Personal personal, Models.LecturasGaritaLog lecturasGaritaLog)
        {
            var PersonalInternos = await _mediator.Send(new GetAllPersonalQuery());
            var PersonalExternos = await _mediator.Send(new GetAllPersonalExternoQuery());
            var existInterno = PersonalInternos.Any(x => x.NroDocumento.ToString() == personalDto.personal.NroDocumento.ToString());
            var existExterno = PersonalExternos.Any(x => x.Dni.ToString() == personalDto.personal.NroDocumento.ToString());
            if (!existInterno)
            {
                if (existExterno)
                {
                    var personalExterno = await _mediator.Send(new GetPersonalExternoByFilterQuery(personalDto.personal.NroDocumento.ToString()));
                    var process = _mediator.Send(new ProcessPersonalExternoCommand(personalExterno.FirstOrDefault(), personalDto.lecturasGaritaLog));
                }
            }
            return Ok();
        }

        [HttpPost("CreateVehiculo")]
        public async Task<IActionResult> CreateVehiculo(CreateVehiculoDTO vehiculoDto)
        {
            var VehiculoInternos = await _mediator.Send(new GetAllVehiculoQuery());
            var VehiculosExternos = await _mediator.Send(new GetAllVehiculosExternosQuery());
            var existInterno = VehiculoInternos.Any(x => x.Dominio.ToString() == vehiculoDto.vehiculo.Dominio.ToString());
            var existExterno = VehiculoInternos.Any(x => x.Dominio.ToString() == vehiculoDto.vehiculo.Dominio.ToString());
            if (!existInterno)
            {
                if (existExterno)
                {
                    var vehiculoExterno = await _mediator.Send(new GetVehiculosExternosByFilterQuery(vehiculoDto.vehiculo.Dominio));
                    var process = await _mediator.Send(new ProcesamientoVehiculoExternoCommand(vehiculoExterno.FirstOrDefault(), vehiculoDto.lecturasGaritaLog));
                }
                else
                {
                    var newVehiculo = new Vehiculo()
                    {
                     Brand = vehiculoDto.vehiculo.Brand,
                     Dominio = vehiculoDto.vehiculo.Dominio,
                     IsActive = Convert.ToInt32(vehiculoDto.vehiculo.IsActive),
                     Model = vehiculoDto.vehiculo.Model
                    };
                    var process = await _mediator.Send(new ProcesamientoVehiculoExternoCommand(newVehiculo, vehiculoDto.lecturasGaritaLog));
                }
            }
            return Ok();
        }

    }
}
