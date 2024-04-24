using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.InvitadosModule.Command;

namespace AccessControlWebRazor.Pages.Invitados
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Invitado Invitado { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            
            await _mediator.Send(new CreateInvitadoCommand(Invitado));

            return RedirectToPage("./Index");
        }
    }
}
