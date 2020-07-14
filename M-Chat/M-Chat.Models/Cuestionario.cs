using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;
using System.Text;

namespace M_Chat.Models
{
    public class Cuestionario
    {
        [Key]
        public int CuestionarioId { get; set; }
        
        [Required]
        public DateTime Fecha_aplicacion { get; set; }
        //Referencias
        
        public List<Preguntas> Preguntas { get; set; }
        public List<Diagnostico> Diagnosticos { get; set; }

    }
}
