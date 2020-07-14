using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Infantes
{
    public class DeleteModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public DeleteModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Infante Infante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Infante = await _context.Infante
                .Include(i => i.Tutor).FirstOrDefaultAsync(m => m.InfanteId == id);

            if (Infante == null)
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

            Infante = await _context.Infante.FindAsync(id);

            if (Infante != null)
            {
                _context.Infante.Remove(Infante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
