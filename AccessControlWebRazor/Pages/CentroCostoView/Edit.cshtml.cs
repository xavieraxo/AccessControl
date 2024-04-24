using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.CentroCostoView
{
    //[Authorize]
    public class EditModel : PageModel
    {
        private readonly AccessControlWebRazor.Data.DataContext _context;

        public EditModel(AccessControlWebRazor.Data.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CentroCostoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentroCostoModelExists(CentroCostoModel.ID))
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

        private bool CentroCostoModelExists(int id)
        {
            return _context.CentroCosto.Any(e => e.ID == id);
        }
    }
}
