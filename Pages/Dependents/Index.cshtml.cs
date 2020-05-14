﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpSys.Data;
using EmpSys.Models;

namespace EmpSys.Pages.Dependents
{
    public class IndexModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;

        public IndexModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }

        public IList<Dependent> Dependent { get;set; }

        public async Task OnGetAsync()
        {
            Dependent = await _context.Dependents
                .Include(d => d.Employee).ToListAsync();
        }
    }
}
