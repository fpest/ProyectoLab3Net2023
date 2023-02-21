using Microsoft.AspNetCore.Mvc;

namespace ProyectoPropioLab3.Controllers;

[ApiController]
[Route("[controller]")]
public class prueba : ControllerBase
{

    
    
    public String Get()
    {
        return "Aca";
    }
}
