﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AccessControlWebRazor.Data.DataContext _context;

        public DetailsModel(AccessControlWebRazor.Data.DataContext context)
        {
            _context = context;
        }

      public LecturasGaritaLog LecturasGaritaLog { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LecturasGaritaLog == null)
            {
                return NotFound();
            }

            var lecturasgaritalog = await _context.LecturasGaritaLog.FirstOrDefaultAsync(m => m.Id == id);
            if (lecturasgaritalog == null)
            {
                return NotFound();
            }
            else 
            {
                LecturasGaritaLog = lecturasgaritalog;
            }
            return Page();
        }
    }
}
