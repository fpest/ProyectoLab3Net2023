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

public class MateriasController : ControllerBase
{
    private readonly DataContext context;
     private readonly IConfiguration config;
    public MateriasController(DataContext dataContext, IConfiguration config)
        {
            
            
            
            this.context = dataContext;
            this.config = config;
        }
       



        [HttpGet("ListarMaterias")]
        // Get Materias
		public async Task<IActionResult> ListarMaterias()
		{
            try
            {

            var id = int.Parse(User.Identity.Name);

              // var i = context.Materia;
               
			  //  var i = context.Materia
              //  .Include(carr => carr.carrera);
			   

			var i = from materia in context.Materia
					join carrera in context.Carrera on materia.carreraid equals carrera.id
					join inscripcionm in context.Inscripcionm on materia.id equals inscripcionm.materiaid
                    where inscripcionm.personaid == id
               		select new {
						ciclolectivo = carrera.ciclolectivo,
						descripcion = materia.descripcion,
						estado = inscripcionm.estado					};



			   
			   
			   
			   return Ok(i);//
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
		
        }



        }



