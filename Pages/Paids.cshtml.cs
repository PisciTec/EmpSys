using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpSys.Data;
using EmpSys.Models;

namespace EmpSys
{
    public class PaidsModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;

        public PaidsModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.Where(e => e.payment == true)
                .Include(e => e.Area).ToListAsync();
        }
    }
}
