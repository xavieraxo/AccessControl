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
    public class DetailsModel : PageModel
    {
        private readonly AccessControlWebRazor.Data.DataContext _context;

        public DetailsModel(AccessControlWebRazor.Data.DataContext context)
        {
            _context = context;
        }

        public Models.Maquinaria MaquinariaModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //MaquinariaModel = await _context.Procesamiento.FirstOrDefaultAsync(m => m.Id == id);

            if (MaquinariaModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
