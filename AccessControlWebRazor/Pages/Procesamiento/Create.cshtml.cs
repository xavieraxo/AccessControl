using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Pages.Procesamiento
{
    public class CreateModel : PageModel
    {
        private readonly AccessControlWebRazor.Data.DataContext _context;

        public CreateModel(AccessControlWebRazor.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Procesamiento ProcesamientoModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Procesamiento.Add(ProcesamientoModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
