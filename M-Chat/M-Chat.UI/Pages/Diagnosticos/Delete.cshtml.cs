using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Diagnosticos
{
    public class DeleteModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public DeleteModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Diagnostico Diagnostico { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Diagnostico = await _context.Diagnostico
                .Include(d => d.Cuestionario)
                .Include(d => d.Infante).FirstOrDefaultAsync(m => m.DiagnosticoId == id);

            if (Diagnostico == null)
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

            Diagnostico = await _context.Diagnostico.FindAsync(id);

            if (Diagnostico != null)
            {
                _context.Diagnostico.Remove(Diagnostico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
