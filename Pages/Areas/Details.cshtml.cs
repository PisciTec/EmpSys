﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpSys.Data;
using EmpSys.Models;

namespace EmpSys.Pages.Areas
{
    public class DetailsModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;

        public DetailsModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }

        public Area Area { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Area = await _context.Areas
                .Include(a => a.Employees)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Area == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
