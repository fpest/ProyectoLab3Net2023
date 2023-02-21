using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPropioLab3.Models
{
    public class Cuentacorriente
    {
        [Key]
        [Display(Name = "Código")]
        public int id { get; set; }
		[Required]
		public string descripcion { get; set; }
	    [Required]
		public double monto { get; set; }
	    [Required]
		public DateTime fechahora { get; set; }
		[Required]
		public int personaid { get; set; }
	   
	}
}
