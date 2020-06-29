using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;
using System.Text;

namespace M_Chat.Models
{
    public class Diagnostico
    {
        [Key]
        public int id_Diagnostico { get; set; }
        [Required]
        public string Resultado { get; set; }

        //Referencias
        [ForeignKey("Infante")]
        public string Curp_Infante { get; set; }
        [ForeignKey("Respuesta")]
        public int id_Respuesta { get; set; }


     }
}
