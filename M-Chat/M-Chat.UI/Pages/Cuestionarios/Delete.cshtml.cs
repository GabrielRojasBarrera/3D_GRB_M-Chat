using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Cuestionarios
{
    public class DeleteModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public DeleteModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cuestionario Cuestionario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cuestionario = await _context.Cuestionario.FirstOrDefaultAsync(m => m.CuestionarioId == id);

            if (Cuestionario == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cuestionario = await _context.Cuestionario.FindAsync(id);

            if (Cuestionario != null)
            {
                _context.Cuestionario.Remove(Cuestionario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
