using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Pregunta
{
    public class DetailsModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public DetailsModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        public Preguntas Preguntas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Preguntas = await _context.Preguntas
                .Include(p => p.Cuestionario).FirstOrDefaultAsync(m => m.PreguntaId == id);

            if (Preguntas == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
