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
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.PersonalExternoView
{
    //[Authorize]
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;
        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public PersonalExterno PersonalExternoModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // PersonalModel = await _context.Personal.FirstOrDefaultAsync(m => m.Id == id);

            //if (PersonaExternolModel == null)
            //{
            //    return NotFound();
            //}
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

           // _context.Attach(PersonalModel).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PersonalModelExists(PersonalModel.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return RedirectToPage("./Index");
        }

        //private bool PersonalModelExists(int id)
        //{
        //    return _context.Personal.Any(e => e.Id == id);
        //}
    }
}
