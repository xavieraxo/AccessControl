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
using AccessControlWebRazor.Modules.UsuarioModule.Command;
using AccessControlWebRazor.Modules.PersonalModule.Queries;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.UsuarioView
{
    [Authorize]
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
        public Usuario Usuario { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var personas = await _mediator.Send(new GetPersonalByFilterQuery("1234567890"));
                var jhonDoeId = personas.FirstOrDefault().Id;
                var result = await _mediator.Send(new CreateUsuarioCommand(Usuario.User, Usuario.Password, jhonDoeId , 2));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToPage("./Index");
        }
    }
}
