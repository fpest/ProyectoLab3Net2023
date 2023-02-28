using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPropioLab3.Models
{
    public class Inscripcionc
    {
        [Key]
        [Display(Name = "Código")]
        public int id { get; set; }
		[Required]
		public int personaid { get; set; }
		[Required]
		public int carreraid { get; set; }
	   [Required]
		public DateTime fechahora { get; set; }
		[Required]
		public string estado { get; set; }
		public Carrera? carrera {get; set;}
	   
	}
}
