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
        public int id_Respuesta { get; set; }
        [Required]
        public bool Respuesta { get; set; }

        //Referencias
        [ForeignKey("Tutor")]
        public  string Email { get; set; }

        [ForeignKey("Pregunta")]
        public string id_Pregunta { get; set; }

        public List<Diagnostico> Diagnosticos { get; set; }
    }
}
