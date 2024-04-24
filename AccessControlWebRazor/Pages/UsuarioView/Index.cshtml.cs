using AccessControlWebRazor.DTO_s.LogInDTO_s;
using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.PersonalModule.Queries;
using AccessControlWebRazor.Modules.UsuarioModule.Queries;
using AccessControlWebRazor.Pages.ProcessPersonalExternoView;
using AccessControlWebRazor.Pages.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccessControlWebRazor.Pages.UsuarioView
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public List<UsuarioDTO> UsuariosDTO { get; set; }
        public async Task OnGetAsync(List<UsuarioDTO> usuarioSearch)
        {
            List<UsuarioDTO> UsuarioModelList = new List<UsuarioDTO>();

            if (usuarioSearch.Count == 0)
            {                
                var personas = await _mediator.Send(new GetAllPersonalQuery());

                List<Usuario> UsuarioModel = await _mediator.Send(new GetAllUserQuery());

                foreach (var item in UsuarioModel)
                {
                    string permiso = "Empleado";
                    if (item.PermisoID == 1)
                    {
                        permiso = "Admin";
                    }
                    var newUser = new UsuarioDTO() 
                    {
                     UsuarioName = item.User.ToUpper(),
                     Persona = personas.FirstOrDefault(x=> x.Id == item.PersonalID).Apellido.ToUpper() +", " +personas.FirstOrDefault(x => x.Id == item.PersonalID).Nombre.ToUpper(),
                     Permiso = permiso.ToUpper(),
                    };
                    UsuarioModelList.Add(newUser);
                    UsuariosDTO = UsuarioModelList;
                }
            }
            else
            {
                UsuariosDTO = usuarioSearch;
            }
        }
        public async Task<IActionResult> OnPostSearch()
        {
            List<UsuarioDTO> UsuarioModelList = new List<UsuarioDTO>();

            if (!String.IsNullOrWhiteSpace(SearchModel.Filter))
            {
                var result = await _mediator.Send(new GetAllUserQuery());
                var personas = await _mediator.Send(new GetAllPersonalQuery());

                foreach (var item in result)
                {
                    string permiso = "Empleado";
                    if (item.PermisoID == 1)
                    {
                        permiso = "Admin";
                    }
                    var newUser = new UsuarioDTO()
                    {
                        UsuarioName = item.User.ToUpper(),
                        Persona = personas.FirstOrDefault(x => x.Id == item.PersonalID).Apellido.ToUpper() + ", " + personas.FirstOrDefault(x => x.Id == item.PersonalID).Nombre.ToUpper(),
                        Permiso = permiso.ToUpper()
                    };
                    UsuarioModelList.Add(newUser);
                }
                var listDepurada = UsuarioModelList.Where(x => x.UsuarioName.ToUpper().Contains(SearchModel.Filter.ToUpper()) || x.Persona.ToUpper().Contains(SearchModel.Filter.ToUpper()) || x.Permiso.ToUpper().Contains(SearchModel.Filter.ToUpper())).ToList();
                await OnGetAsync(listDepurada);
                return Page();
            }
            else
            {
                var result = await _mediator.Send(new GetAllUserQuery());
                var personas = await _mediator.Send(new GetAllPersonalQuery());

                foreach (var item in result)
                {
                    string permiso = "Empleado";
                    if (item.PermisoID == 1)
                    {
                        permiso = "Admin";
                    }
                    var newUser = new UsuarioDTO()
                    {
                        UsuarioName = item.User.ToUpper(),
                        Persona = personas.FirstOrDefault(x => x.Id == item.PersonalID).Apellido.ToUpper() + ", " + personas.FirstOrDefault(x => x.Id == item.PersonalID).Nombre.ToUpper(),
                        Permiso = permiso.ToUpper(),
                    };
                    UsuarioModelList.Add(newUser);
                }
                await OnGetAsync(UsuarioModelList);
                return Page();
            }
        }
    }
}
