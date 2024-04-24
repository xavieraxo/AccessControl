using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Pages
{
    public class EditModel : PageModel
    {
        private readonly AccessControlWebRazor.Data.DataContext _context;

        public EditModel(AccessControlWebRazor.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LecturasGaritaLog LecturasGaritaLog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LecturasGaritaLog == null)
            {
                return NotFound();
            }

            var lecturasgaritalog =  await _context.LecturasGaritaLog.FirstOrDefaultAsync(m => m.Id == id);
            if (lecturasgaritalog == null)
            {
                return NotFound();
            }
            LecturasGaritaLog = lecturasgaritalog;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LecturasGaritaLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturasGaritaLogExists(LecturasGaritaLog.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LecturasGaritaLogExists(int id)
        {
          return (_context.LecturasGaritaLog?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
