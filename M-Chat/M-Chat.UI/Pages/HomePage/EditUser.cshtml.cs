using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.HomePage
{
    public class EditModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public EditModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tutor Tutor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tutor = await _context.Tutor.FirstOrDefaultAsync(m => m.TutorId == id);

            if (Tutor == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(Tutor.TutorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect("./DetailsUser?id=" + Tutor.TutorId);
        }

        private bool TutorExists(int id)
        {
            return _context.Tutor.Any(e => e.TutorId == id);
        }
    }
}
