using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Respuesta
{
    public class DeleteModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public DeleteModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Respuestas Respuestas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Respuestas = await _context.Respuestas
                .Include(r => r.Preguntas).FirstOrDefaultAsync(m => m.RespuestaId == id);

            if (Respuestas == null)
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

            Respuestas = await _context.Respuestas.FindAsync(id);

            if (Respuestas != null)
            {
                _context.Respuestas.Remove(Respuestas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
