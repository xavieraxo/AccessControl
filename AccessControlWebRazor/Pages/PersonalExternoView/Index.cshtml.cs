using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using AccessControlWebRazor.Pages.Shared;
using AccessControlWebRazor.Modules.InvitadosModule.Queries;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.PersonalExternoView
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public List<PersonalExterno> PersonalExternoModel { get; set; }

        public async Task OnGetAsync(List<PersonalExterno> PersonalExterno)
        {
            if (PersonalExterno.Count == 0)
            {
                PersonalExternoModel = await _mediator.Send(new GetAllPersonalExternoQuery());
                if (PersonalExternoModel != null)
                {
                    foreach (var personal in PersonalExternoModel)
                    {
                        // Verifica si la propiedad Modificado es nula
                        personal.LastName ??= "";
                        personal.Cuil ??= "";
                        personal.Dni ??= "";
                        personal.FirstName ??= "";

                    }
                }
            }
            else
            {
                PersonalExternoModel = PersonalExterno;
            }

        }

        public async Task<IActionResult> OnPostSearch()
        {
            if (!String.IsNullOrWhiteSpace(SearchModel.Filter))
            {
                var result = await _mediator.Send(new GetPersonalExternoByFilterQuery(SearchModel.Filter));
                await OnGetAsync(result);
                return Page();
            }
            else
            {
                var result = await _mediator.Send(new GetAllPersonalExternoQuery());
                await OnGetAsync(result);
                return Page();
            }
        }
    }
}
