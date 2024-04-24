using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;

using AccessControlWebRazor.Modules.ProcessExternalModule.Command;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.ProcessPersonalExternoView
{
    //[Authorize]
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public ProcesamientoPersonalExterno Procesamiento { get; set; }
        public IList<CentroCosto> CostoEntities { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procesamiento = await _mediator.Send(new GetProcesamientoExternoByIdQuery((int)id));

            if (Procesamiento == null)
            {
                return NotFound();
            }

            CostoEntities = await _mediator.Send(new GetAllCentroCostoQuery());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                CentroCosto centroCostoModel = await _mediator.Send(new GetCentroCostoByIdQuery(Procesamiento.CentroCostoId));
                Procesamiento.CentroCostoDesc = centroCostoModel.Descripcion;
                Procesamiento.EstadoFichada = "Ok";
                var result = await _mediator.Send(new UpdateProcessPersonalExternoCommand(Procesamiento));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToPage("./Index");
        }


    }
}
