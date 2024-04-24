using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.InvitadosModule.Queries;
using AccessControlWebRazor.Pages.Shared;

namespace AccessControlWebRazor.Pages.Invitados
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public IList<Invitado> InvitadoModel { get; set; }

        public async Task OnGetAsync(List<Invitado> Invitado)
        {
            if (Invitado.Count == 0)
            {
                InvitadoModel = await _mediator.Send(new GetAllInvitadosQuery());
                foreach(var persona in InvitadoModel)
                {
                    persona.Apellido ??= "-";
                    persona.DNI ??= "-";
                    persona.Observacion ??= "-";
                    persona.Nombre ??= "-";
                    persona.Nombre ??= "-";
                    persona.Mail ??= "-";
                    persona.Telefono ??= "-";
                }
            }
            else
            {
                InvitadoModel = Invitado;
            }
        }

        public async Task<IActionResult> OnPostSearch()
        {
            if (!String.IsNullOrWhiteSpace(SearchModel.Filter))
            {
                var result = await _mediator.Send(new GetInvitadosByFilterQuery(SearchModel.Filter));
                await OnGetAsync(result);
                return Page();
            }
            else
            {
                var result = await _mediator.Send(new GetAllInvitadosQuery());
                await OnGetAsync(result);
                return Page();
            }
        }
    }
}
