using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final1ProgClinica.Models
{
    public class ClassAltas
    {
        [Key]
        public int ID_Altas { get; set; }

        [Required]
        public int ID_Ingresos { get; set; }
        [ForeignKey("ID_Ingresos")]
        public ClassIngresos Ingresos { get; set; }

        [Required]
        public int Monto_Pagar { get; set; }

        [Required]
        public int ID_Paciente { get; set; }
       
        [Required]
        public int ID_Habitacion { get; set; }
       

        [Required]
        public string Fecha_Ingreso { get; set; }
    }
}