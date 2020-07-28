using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using M_Chat.Models;
using M_Chat.Services;
using System.Security.Policy;

namespace M_Chat.UI.Pages.Respuesta
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
        ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "Pregunta");
            return Page();
        }
       
        [BindProperty]
        public Respuestas Respuestas { get; set; }
        [BindProperty]
        public Preguntas Preguntas { get; set; }
        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            IList<Respuestas> newrespuesta = new List<Respuestas>(){
           

                new Respuestas() { PreguntaId = 1,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 2 ,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 3,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 4,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 5 ,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 6,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 7,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 8 ,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 9,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 10,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 11 ,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 12,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 13,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 14 ,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 15,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 16,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 17 ,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 18,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 19,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 20 ,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 21,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 22,Respuesta=checked(Respuestas.Respuesta)},
                new Respuestas() { PreguntaId = 23 ,Respuesta=checked(Respuestas.Respuesta)},
                
            };
            foreach (var context in newrespuesta)
            {
                
                _context.Respuestas.AddRange(context);
                _context.SaveChanges();

            }
               
            return RedirectToPage("./Index");
        }
        



    }
}
