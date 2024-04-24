using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Pages.CentroCostoView
{
    public class DeleteModel : PageModel
    {
        private readonly AccessControlWebRazor.Data.DataContext _context;

        public DeleteModel(AccessControlWebRazor.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.CentroCosto CentroCostoModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CentroCostoModel = await _context.CentroCosto.FirstOrDefaultAsync(m => m.ID == id);

            if (CentroCostoModel == null)
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

            CentroCostoModel = await _context.CentroCosto.FindAsync(id);

            if (CentroCostoModel != null)
            {
                _context.CentroCosto.Remove(CentroCostoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
