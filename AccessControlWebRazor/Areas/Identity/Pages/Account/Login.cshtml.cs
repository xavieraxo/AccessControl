using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AccessControlWebRazor.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using AccessControlWebRazor.Modules.UsuarioModule.Command;
using AccessControlWebRazor.Modules.LogInModule.Queries;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using AccessControlWebRazor.Controllers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using AccessControlWebRazor.Modules.VehiculosModule.Command;
using AccessControlWebRazor.Modules.CertronicModule.Command;

namespace AccessControlWebRazor.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticationSchemeProvider _authenticationSchemeProvider;


        public LoginModel(IMediator mediator, IAuthenticationSchemeProvider authenticationSchemeProvider)
        {
            _mediator = mediator;
            _authenticationSchemeProvider = authenticationSchemeProvider;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string User { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var login = await _mediator.Send(new LogInQuery(Input.User, Input.Password));

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.User),
                    new Claim(ClaimTypes.Role, login.Permiso.ToString()),
                    // Agregar más claims según sea necesario
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                await _mediator.Send(new SincronizarCertronicCommand());

                return RedirectToPage(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
