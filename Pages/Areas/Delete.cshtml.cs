using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpSys.Models;

namespace EmpSys.Pages.Areas
{
    public class DeleteModel : PageModel
    {
        private readonly EmpSys.Data.EmpContext _context;
            
        public DeleteModel(EmpSys.Data.EmpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Area Area { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError= false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Area = await _context.Areas
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Area == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Deleção falhou, tente novamente!";
            }

            return Page();

            
        }

        public async Task<IActionResult> OnPostAsync(int? id)
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

            try
            {
                _context.Areas.Remove(Area);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Para mostrar o erro, descomentar a variável ex e escrever um log.
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}
