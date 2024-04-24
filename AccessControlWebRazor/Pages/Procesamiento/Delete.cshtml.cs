using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Pages.Procesamiento
{
    public class DeleteModel : PageModel
    {
        private readonly AccessControlWebRazor.Data.DataContext _context;

        public DeleteModel(AccessControlWebRazor.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Procesamiento ProcesamientoModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProcesamientoModel = await _context.Procesamiento.FirstOrDefaultAsync(m => m.Id == id);

            if (ProcesamientoModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProcesamientoModel = await _context.Procesamiento.FindAsync(id);

            if (ProcesamientoModel != null)
            {
                _context.Procesamiento.Remove(ProcesamientoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
