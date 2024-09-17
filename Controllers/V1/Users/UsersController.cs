using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_nemura.Data;

namespace WebAPI_Nemura.Controllers.V1.Users;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    // Esta propiedad es nuestra llave para entrar a la base de datos.
    private readonly ApplicationDbContext Context;

    // Builder. Este constructor se va a encargar de hacerme la conexión con la base de datos con ayuda de la llave.
    public UsersController(ApplicationDbContext context)
    {
        Context = context;
    }
}
