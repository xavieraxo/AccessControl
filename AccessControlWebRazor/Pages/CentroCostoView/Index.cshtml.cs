using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using AccessControlWebRazor.Pages.Shared;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.CentroCostoView
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
        public IList<CentroCosto> CentroCostoModel { get; set; }

        public async Task OnGetAsync(List<CentroCosto> CentroCosto)
        {
            if (CentroCosto.Count == 0)
            {
                CentroCostoModel = await _mediator.Send(new GetAllCentroCostoQuery());

                foreach (var centroCosto in CentroCostoModel)
                {
                    centroCosto.Nombre ??= "";
                    centroCosto.Codigo ??= "";
                    centroCosto.Descripcion ??= "";
                }
            }
            else
            {
                CentroCostoModel = CentroCosto;
            }
        }

        public async Task<IActionResult> OnPostSearch() 
        {
            if (!String.IsNullOrWhiteSpace(SearchModel.Filter))
            {
                var result = await _mediator.Send(new GetCentroDeCostoByFilterQuery(SearchModel.Filter));
                await OnGetAsync(result);
                return Page();
            }
            else
            {
                var result = await _mediator.Send(new GetAllCentroCostoQuery());
                await OnGetAsync(result);
                return Page();
            }
        }
    }
}
