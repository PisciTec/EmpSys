using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpSys.Data;
using EmpSys.Models;

namespace EmpSys
{
    public class EditModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;

        public EditModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Area Area { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Area = await _context.Areas.FindAsync(id);

            if (Area == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var areaToUpdate = await _context.Areas.FindAsync(id);

            if (areaToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Area>(areaToUpdate, "area", a => a.name))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();

        }
    
    }
}
