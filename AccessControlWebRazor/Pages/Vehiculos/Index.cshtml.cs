using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Pages.Shared;
using AccessControlWebRazor.Modules.VehiculosModule.Queries;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.Vehiculos
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
        public IList<Vehiculo> Vehiculo { get;set; }

        public async Task OnGetAsync(List<Vehiculo> vehiculos)
        {
            if (vehiculos.Count == 0)
            {
                Vehiculo = await _mediator.Send(new GetAllVehiculoQuery());
            }
            else
            {
                Vehiculo = vehiculos;
            }
        }

        public async Task<IActionResult> OnPostSearch()
        {
            if (!String.IsNullOrWhiteSpace(SearchModel.Filter))
            {
                var result = await _mediator.Send(new GetVehiculosByFilterQuery(SearchModel.Filter));
                await OnGetAsync(result);
                return Page();
            }
            else
            {
                var result = await _mediator.Send(new GetAllVehiculoQuery());
                await OnGetAsync(result);
                return Page();
            }
        }
    }
}
