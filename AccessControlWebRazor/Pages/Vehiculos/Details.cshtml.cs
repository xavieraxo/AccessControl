using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.VehiculosModule.Queries;

namespace AccessControlWebRazor.Pages.Vehiculos
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Vehiculo Vehiculo { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo = await _mediator.Send(new GetByDominioVehiculoQuery((string)id));

            if (Vehiculo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
