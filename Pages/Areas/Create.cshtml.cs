﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmpSys.Data;
using EmpSys.Models;

namespace EmpSys.Pages.Areas
{
    public class CreateModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;

        public CreateModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AreaVM AreaVM { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var entry = _context.Add(new Area());
            entry.CurrentValues.SetValues(AreaVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
        }
    }
}
