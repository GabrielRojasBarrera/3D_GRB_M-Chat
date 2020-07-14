using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Infantes
{
    public class CreateModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public CreateModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TutorId"] = new SelectList(_context.Tutor, "TutorId", "Email");
        ViewData["CentroId"] = new SelectList(_context.Centro_Educativo, "CentroId", "Nombre_CentroEducativo");

            return Page();
        }

        [BindProperty]
        public Infante Infante { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Infante.Add(Infante);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
