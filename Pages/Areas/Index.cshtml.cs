using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpSys.ScriptsExtras;
using EmpSys.Models;

namespace EmpSys
{
    public class IndexModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;

        public IndexModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }
        public string NameSort{get; set;}
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Area> Areas { get; set; }
        public async Task OnGetAsync(string sortOrder, string currentFilter,  string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;
            IQueryable<Area> areasIQ = from a in _context.Areas select a;

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                areasIQ = areasIQ.Where(a => a.name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    areasIQ = areasIQ.OrderByDescending(a => a.name);
                    break;
                default:
                    areasIQ = areasIQ.OrderBy(a => a.name);
                    break;
            }
            int pageSize = 3;
            Areas = await PaginatedList<Area>.CreateAsync(areasIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
