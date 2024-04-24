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
using AccessControlWebRazor.Modules.UsuarioModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using AccessControlWebRazor.Modules.ProcessExternalModule.Command;
using AccessControlWebRazor.Modules.UsuarioModule.Command;

using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.UsuarioView
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usuario = await _mediator.Send(new GetUserByPersonalIDQuery((int)id));

            if (Usuario == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
       

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var result = await _mediator.Send(new CreateUsuarioCommand(Usuario.User, Usuario.Password, Usuario.PersonalID, Usuario.PermisoID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToPage("./Index");
        }
    }
}
