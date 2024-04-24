using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Pages.Vehiculos
{
    public class DeleteModel : PageModel
    {
        private readonly AccessControlWebRazor.Data.DataContext _context;

        public DeleteModel(AccessControlWebRazor.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehiculo Vehiculo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(m => m.Id == id);

            if (Vehiculo == null)
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

            Vehiculo = await _context.Vehiculos.FindAsync(id);

            if (Vehiculo != null)
            {
                _context.Vehiculos.Remove(Vehiculo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
