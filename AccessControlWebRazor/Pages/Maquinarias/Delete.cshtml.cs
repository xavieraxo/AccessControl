using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Pages.Maquinarias
{
    public class DeleteModel : PageModel
    {
        private readonly AccessControlWebRazor.Data.DataContext _context;

        public DeleteModel(AccessControlWebRazor.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Maquinaria MaquinariaModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // MaquinariaModel = await _context.Procesamiento.FirstOrDefaultAsync(m => m.Id == id);

            if (MaquinariaModel == null)
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

            //MaquinariaModel = await _context.Procesamiento.FindAsync(id);

            if (MaquinariaModel != null)
            {
               // _context.Procesamiento.Remove(MaquinariaModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
