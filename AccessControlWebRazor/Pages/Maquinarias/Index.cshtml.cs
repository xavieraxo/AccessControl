using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using Microsoft.AspNetCore.Authorization;
using AccessControlWebRazor.Modules.CertronicModule.Command;
using AccessControlWebRazor.Modules.ProdengVehiculosModule.Command;
using AccessControlWebRazor.HikVisionIntegration;
using AccessControlWebRazor.Modules.ProdengVehiculosModule.Queries;

namespace AccessControlWebRazor.Pages.Maquinarias
{

    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;


        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;

        }

        public IList<Models.Maquinaria> MaquinariaModel { get; set; }

        public async Task OnGetAsync(List<Models.Maquinaria> Maquinaria)
        {
            //if (Maquinaria.Count == 0)
            //{

            //    MaquinariaModel = await _mediator.Send(new GetAllVehiculoProdengQuery());

            //    foreach (var maquina in MaquinariaModel)
            //    {
            //        // Verifica si la propiedad Modificado es nula
            //        maquina.Number ??= "-";
            //        maquina.Brand ??= "-";
            //        maquina.Description ??= "-";
            //    }
            //}
            //else
            //{
            //    MaquinariaModel = Maquinaria;
            //}
        }


    }
}
