using MailKit.Net.Smtp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using ProyectoPropioLab3.Models;

namespace ProyectoPropioLab3.Controllers;

[ApiController]
[Route("[controller]")]
//Para autorizar
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class RegistronotasController : ControllerBase
{
    private readonly DataContext context;
     private readonly IConfiguration config;
    public RegistronotasController(DataContext dataContext, IConfiguration config)
        {
            
            
            
            this.context = dataContext;
            this.config = config;
        }
       



        [HttpGet("ListarNotas")]
        // Get Materias
		public async Task<IActionResult> ListarNotas()
		{
            try
            {

            var id = int.Parse(User.Identity.Name);

              // var i = context.Materia;
               
			  //  var i = context.Materia
              //  .Include(carr => carr.carrera);
			   
 
			var i = from notas in context.Registronotas
					join inscripcionm in context.Inscripcionm on notas.inscripcionmid equals inscripcionm.id
                    join materia in context.Materia on inscripcionm.materiaid equals materia.id
                    where inscripcionm.personaid == id orderby notas.fecha descending
               		select new {
						nota = notas.nota,
                        fecha = notas.fecha.ToString("dd/MM/yyyy"),
                        descripcion = materia.descripcion			};
                        


			   
			   
			   
			   return Ok(i);//
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
		
        }



        }



