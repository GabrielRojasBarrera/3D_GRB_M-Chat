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
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;

namespace M_Chat.UI.Pages.Respuesta
{
    public class CreateModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;
        private readonly IWebHostEnvironment hostEnviroment;
        public CreateModel(M_Chat.Services.AppDBContext context, IWebHostEnvironment _hostEnviroment)
        {
            hostEnviroment = _hostEnviroment;
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
        public string Email { get; set; }
        [BindProperty]
        public Cuestionario cuestionario { get; set; }
        [BindProperty]
        public Diagnostico Diagnostico { get; set; }
        [BindProperty]
        public Tutor tutor { get; set; }
        [BindProperty]
        public Infante infante { get; set; }
        [BindProperty]
        public string Resultado { get; set; }



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


            }
            GenDiag();
            Diagnostico.InfanteId = infante.InfanteId = 2;
            Diagnostico.CuestionarioId = cuestionario.CuestionarioId = 1;
            Diagnostico.Resultado = Resultado;
            _context.Diagnostico.Add(Diagnostico);
            _context.SaveChanges();
            Correo(_context.Infante.Where(n => n.InfanteId == Diagnostico.InfanteId).First().Nombre, Respuestas);
            return RedirectToPage("../Infantes/Index");
        }
        public void GenDiag()
        {
            
            int criticas = Preguntas.PreguntaId = 2; Preguntas.PreguntaId = 7; Preguntas.PreguntaId = 9; Preguntas.PreguntaId = 13; Preguntas.PreguntaId = 14; Preguntas.PreguntaId = 15;
            int normales = Preguntas.PreguntaId = 1; Preguntas.PreguntaId = 3; Preguntas.PreguntaId = 4; Preguntas.PreguntaId = 5; Preguntas.PreguntaId = 6; Preguntas.PreguntaId = 8; Preguntas.PreguntaId = 10; Preguntas.PreguntaId = 11; Preguntas.PreguntaId = 12; Preguntas.PreguntaId = 16; Preguntas.PreguntaId = 17; Preguntas.PreguntaId = 18; Preguntas.PreguntaId = 19; Preguntas.PreguntaId = 20; Preguntas.PreguntaId = 21; Preguntas.PreguntaId = 22; Preguntas.PreguntaId = 23;

            if (criticas>2)
            {
                Resultado = "Posible autismo";
            }
            else if(normales>3)
            {
                Resultado = "Posible Autismo";
            }
            else
            {
                Resultado = "Sin Singnos de Autismo";
            }
           

        }

        public void Correo(string nombre, Respuestas respuestas)
        {
            var ServicioDeCorreo = new EmailSystem();
            var File = new Attachment(PDF.CrearPdf(nombre, respuestas, hostEnviroment.WebRootPath), $"Resultados.pdf");
            if (Diagnostico.Resultado == "Posible autismo")
            {
                ServicioDeCorreo.EnviarCorreo(
                        Asunto: "Deteccion del Autismo",
                        Cuerpo: $"Su hijo  tiene probabilidad de autismo",
                        Destinatarios: new List<string> { Email },
                        File
                        );
            }
            else
            {
                ServicioDeCorreo.EnviarCorreo(
                    Asunto: "Deteccion del Autismo",
                    Cuerpo: $"Su hijo no tiene probabilidad de autismo",
                    Destinatarios: new List<string> { Email },
                    File
                    );
            }
        }

    }
}
