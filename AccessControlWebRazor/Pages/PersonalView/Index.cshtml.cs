using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using AccessControlWebRazor.Modules.PersonalModule.Queries;
using Microsoft.AspNetCore.Mvc;
using AccessControlWebRazor.Pages.Shared;
using AccessControlWebRazor.Modules.CertronicModule.Queries;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.PersonalView
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

        public IList<Models.Personal> PersonalModel = new List<Models.Personal>();


        public async Task OnGetAsync(List<Models.Personal> Personal)
        {
            if (Personal.Count == 0)
            {
                PersonalModel = await _mediator.Send(new GetAllPersonalQuery());
                foreach (var personal in PersonalModel)
                {
                    // Verifica si la propiedad Modificado es nula
                    personal.IdTipoDocumento ??= 0;
                    personal.NroDocumento ??= 0;
                    personal.Localidad ??= "";
                    personal.Email ??= "";
                }
            }
            else
            {
                PersonalModel = Personal;
            }
        }

        public async Task<IActionResult> OnPostSearch()
        {
            if (!String.IsNullOrWhiteSpace(SearchModel.Filter))
            {
                var result = await _mediator.Send(new GetPersonalByFilterQuery(SearchModel.Filter));
                await OnGetAsync(result);
                return Page();
            }
            else
            {
                var result = await _mediator.Send(new GetAllPersonalQuery());
                await OnGetAsync(result);
                return Page();
            }
        }

    }
}
