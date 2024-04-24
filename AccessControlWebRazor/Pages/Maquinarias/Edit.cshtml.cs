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

using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.Maquinarias
{
    //[Authorize]
    public class EditModel : PageModel
    {
        private readonly DataContext _context;
        

        [BindProperty]
        public Models.Maquinaria MaquinariaModel { get; set; }
       
       

        public EditModel(DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //MaquinariaModel = _context.Procesamiento.FirstOrDefault(m => m.Id == id);

            if (MaquinariaModel == null)
            {
                return NotFound();
            }

            //var listcosto = _dataManager.GetCentroDeCosto();

          

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.

        public IActionResult OnPostAsync()
        {
            //var uno = Procesamiento;
            //var tres = Procesamiento.CentroCostoModel;
            //var otro = costoEntities;
            //int centroCostoSeleccionado = Procesamiento.CentroCostoId;
            ////var loquesea = ModelState.Values;
            //Procesamiento.CentroCostoDesc = Procesamiento.CentroCostoModel.Codigo;
            ////var uno = ModelState.Keys;

            ////if (!ModelState.IsValid)
            ////{
            ////    return Page();
            ////}
            //_dataManager.UpdateProcesamiento(Procesamiento.Id, Procesamiento.CentroCostoModel.Codigo);
            //_context.Attach(Procesamiento).State = EntityState.Modified;

            ////try
            ////{
            ////     _context.SaveChangesAsync();
            ////}
            ////catch (DbUpdateConcurrencyException)
            ////{
            ////    if (!ProcesamientoModelExists(Procesamiento.Id))
            ////    {
            ////        return NotFound();
            ////    }
            ////    else
            ////    {
            ////        throw;
            ////    }
            //}

            return RedirectToPage("./Index");
        }

        private bool ProcesamientoModelExists(int id)
        {
            // return _context.MaquinariaModel.Any(e => e.Id == id);
            return false;
        }


        //public IActionResult OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    CentroCostoId = Convert.ToInt32(costoEntities.Select(x => x.ID));

        //    Procesamiento.CentroCostoId = CentroCostoId;

        //    _context.Attach(Procesamiento).State = EntityState.Modified;

        //    try
        //    {
        //        _context.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProcesamientoExists(Procesamiento.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

    }
}

/*
 * 
 * [BindProperty]
        public ProcesamientoModel ProcesamientoModel { get; set; }

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProcesamientoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcesamientoModelExists(ProcesamientoModel.Id))
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

        private bool ProcesamientoModelExists(int id)
        {
            return _context.Procesamiento.Any(e => e.Id == id);
        }
 * 
 * */
