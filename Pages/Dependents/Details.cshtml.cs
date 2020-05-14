using System;
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
    public class DetailsModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;

        public DetailsModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }

        public Dependent Dependent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dependent = await _context.Dependents
                .Include(d => d.Employee).FirstOrDefaultAsync(m => m.ID == id);

            if (Dependent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
