using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPropioLab3.Models
{
    public class MisCarrerasView
    {
        [Key]
        [Display(Name = "Código")]
        public int carreraid { get; set; }
		[Required]
		public String descripcion { get; set; }
		[Required]
		public int ciclolectivo { get; set; }
       [Required]
        public String estado { get; set; }
        
	}
}
