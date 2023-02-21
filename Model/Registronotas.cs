using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPropioLab3.Models
{
    public class Registronotas
    {
        [Key]
        [Display(Name = "Código")]
        public int id { get; set; }
		[Required]
		public double nota { get; set; }
	    [Required]
		public DateOnly fecha { get; set; }
		[Required]
		public int inscripcionmid { get; set; }
	   
	}
}
