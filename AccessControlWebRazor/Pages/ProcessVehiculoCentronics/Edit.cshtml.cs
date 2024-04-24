using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Command;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.ProcessVehiculoCentronics
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
        public ProcesamientoVehiculoExterno ProcesamientoVehiculoExterno { get; set; }

        public IList<CentroCosto> costoEntities { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProcesamientoVehiculoExterno = await _mediator.Send(new GetByIDProcessVehiExtQuery((int)id));

            if (ProcesamientoVehiculoExterno == null)
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
           

            try
            {
                CentroCosto centroCostoModel = await _mediator.Send(new GetCentroCostoByIdQuery(ProcesamientoVehiculoExterno.CentroCostoID));
            
                ProcesamientoVehiculoExterno.CentroCostoDesc = centroCostoModel.Descripcion;
                ProcesamientoVehiculoExterno.EstadoFichado = "Ok";

                await _mediator.Send(new UpdateProcessVehiculoExtCommand(ProcesamientoVehiculoExterno));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ProcesamientoVehiculoExterno == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        
    }
}
