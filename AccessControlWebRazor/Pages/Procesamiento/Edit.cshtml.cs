using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Command;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.Procesamiento
{
    //[Authorize]
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;
        

        [BindProperty]
        public Models.Procesamiento Procesamiento { get; set; }
        public IList<CentroCosto> costoEntities { get; set; }

        [BindProperty]
        public int CentroCostoId { get; set; }

        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procesamiento = await _mediator.Send(new GetProcesamientoByIDQuery((int)id));

            if (Procesamiento == null)
            {
                return NotFound();
            }

            costoEntities = await _mediator.Send(new GetAllCentroCostoQuery());

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {   
            CentroCosto centroCostoModel = await _mediator.Send(new GetCentroCostoByIdQuery(Procesamiento.CentroCosto));
            Procesamiento.CentroCostoDesc = centroCostoModel.Descripcion;
            Procesamiento.EstadoFichada = "Ok";

            await _mediator.Send(new UpdateProcesamientoCommand(Procesamiento));

            return RedirectToPage("./Index");
        }

    }
}
