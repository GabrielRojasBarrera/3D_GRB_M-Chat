﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Pregunta
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
        ViewData["CuestionarioId"] = new SelectList(_context.Cuestionario, "CuestionarioId", "CuestionarioId");
            return Page();
        }

        [BindProperty]
        public Preguntas Preguntas { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Preguntas.Add(Preguntas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
