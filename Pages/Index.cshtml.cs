using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EmpSys.Data;
using EmpSys.Models.DashboardViewsModels;
using EmpSys.Models;

namespace EmpSys.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, EmpSys.Data.EmpContext context)
        {
            _logger = logger;
            _context = context;
        }
        public Area Area { get; set; }
        public IList<EmployeeGroup> Employees { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<EmployeeGroup> data = from employee in _context.Employees
                                         group employee by employee.Area.name into areaGroup
                                         select new EmployeeGroup()
                                         {
                                             AreaName = areaGroup.Key,
                                             EmployeeCount = areaGroup.Count()
                                         };
            Employees = await data.AsNoTracking().ToListAsync();
        }
    }
}
