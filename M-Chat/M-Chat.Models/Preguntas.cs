using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace M_Chat.Models
{
    public class Preguntas
    {
        [Key]
        public int id_Pregunta { get; set; }
        [Required]
        public string Respuesta { get; set; }
        //Referencias
        [ForeignKey("Cuestionario")]
        public int id_Cuestionario { get; set; }
      
        public List<Respuestas> Respuestas { get; set; }

    }
}
