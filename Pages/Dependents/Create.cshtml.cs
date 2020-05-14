using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmpSys.Data;
using EmpSys.Models;

namespace EmpSys.Pages.Dependents
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
        ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "name");
            return Page();
        }

        [BindProperty]
        public Dependent Dependent { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dependents.Add(Dependent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
