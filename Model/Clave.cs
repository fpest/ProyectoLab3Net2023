using System.ComponentModel.DataAnnotations;
using ProyectoPropioLab3.Models;

namespace ProyectoPropioLab3.Models
{
    public class Clave
    {
        [Required]
        public string passwordActual { get; set; }

        [Required]
        public string passwordNueva1 { get; set; }

        [Required]
        public string passwordNueva2 { get; set; }
     
        public string mensaje { get; set; }
       		       
    
}}
