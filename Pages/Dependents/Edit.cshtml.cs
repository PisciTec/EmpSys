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

namespace EmpSys.Pages.Dependents
{
    public class EditModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;

        public EditModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dependent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DependentExists(Dependent.ID))
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

        private bool DependentExists(int id)
        {
            return _context.Dependents.Any(e => e.ID == id);
        }
    }
}
