using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Queries;
using AccessControlWebRazor.Services;
using AccessControlWebRazor.HikVisionIntegration;
using AccessControlWebRazor.Pages.Shared;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries;

namespace AccessControlWebRazor.Pages
{
    public class LecturaPatentesModel : PageModel
    {
        private readonly IMediator _mediator;

        private readonly IAllProcesamientosServices _allProcesamientosServices;
        private readonly IHvAC _hvAC;


        public LecturaPatentesModel(IMediator mediator, IAllProcesamientosServices allProcesamientosServices, IHvAC hvAC)
        {
            _mediator = mediator;
            _allProcesamientosServices = allProcesamientosServices;
            _hvAC = hvAC;
        }
        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public List<LecturaPatente> LecturaPatentes { get; set; }

        public async Task OnGetAsync(List<LecturaPatente> lecturasP)
        {
            if (lecturasP.Count == 0)
            {
                var lecturasp = _mediator.Send(new GetLecturasPatenteDelDiaQuery()).Result.ToList();
                if (lecturasp.Count > 0)
                {
                    LecturaPatentes = lecturasp.ToList();
                    foreach (var lectura in LecturaPatentes)
                    {
                        // Verifica si la propiedad Modificado es nula
                        lectura.Patente ??= "";
                        lectura.FechaLectura ??= "";
                        lectura.Camara ??= "";

                    }
                }
                else
                {
                    LecturaPatentes = new List<LecturaPatente>();
                }

            }
            else
            {
                LecturaPatentes = lecturasP;
            }


        }
        public async Task<IActionResult> OnPostCloseDoor()
        {
            _hvAC.OperationDoor(1, 2);
            var result = await _mediator.Send(new GetLecturasPatenteDelDiaQuery());
            await OnGetAsync(result.Where(x => x.Procesado == 0).ToList());
            return Page();
        }

        public async Task<IActionResult> OnPostProcessAll()
        {
            _allProcesamientosServices.ProcesarVehiculos();
            _allProcesamientosServices.ProcesarPersonas();
            var result = await _mediator.Send(new GetLecturasPatenteDelDiaQuery());
            await OnGetAsync(result.Where(x => x.Procesado == 0).ToList());
            return Page();
        }
        public async Task<IActionResult> OnPostSearch()
        {
            var query = new GetLecturaPatentesByDominioQuery(SearchModel.Filter);
            var result = await _mediator.Send(query);
            await OnGetAsync(result);
            return Page();
        }
    }
}
