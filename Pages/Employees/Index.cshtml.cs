using System;
using System.Collections.Generic;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpSys.Models;

namespace EmpSys.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;

        public IndexModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }
        public string Payment { get; set; }
        public IList<Employee> Employees { get;set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                .Include(e => e.Area).AsNoTracking().ToListAsync();
            //if (payment != null)
            //{
            //    var employeeToUpdate = await _context.Employees.FindAsync(id);
            //}
        }
    }
}
