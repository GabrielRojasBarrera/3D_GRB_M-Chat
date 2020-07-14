using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace M_Chat.Models
{
    public class Respuestas
    {
        [Key]
        public int RespuestaId { get; set; }
        [Required]
        public bool Respuesta { get; set; }

        //Referencias
        
        [ForeignKey("Preguntas")]
        public int PreguntaId { get; set; }
        public Preguntas Preguntas { get; set; }


    }
}
