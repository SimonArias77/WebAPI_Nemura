using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_nemura.Data;

namespace WebAPI_Nemura.Controllers.V1.Assignments;

[ApiController] //Atributo que marca la clase como un controlador de API en ASP.NET Core. Proporciona características adicionales, como la validación automática del modelo y la respuesta de errores en formato JSON
[Route("api/[controller]")] // Atributo que define la ruta de acceso para las solicitudes HTTP que se dirigen a este controlador. [controller] es un marcador de posición que se reemplaza por el nombre del controlador sin la palabra "Controller". En este caso, AssignmentsController se mapea a la ruta api/Assignments.
public class AssignmentsController : ControllerBase //Clase base para controladores en ASP.NET Core que no requieren vistas (se utiliza para APIs). Proporciona funcionalidades básicas para manejar solicitudes y respuestas.
{
    //Esta propiedad es nuestra llave para entrar a la base de datos
    private readonly ApplicationDbContext Context; //readonly: Modificador que indica que el campo solo se puede asignar en el constructor o en su declaración. Esto asegura que el valor de la propiedad no cambie después de la inicialización.

    //Builder. Este es el constructor se va a encargar de hacerme la conexión con la base de datos por meido de la llave o propiedad. 

    public AssignmentsController (ApplicationDbContext context)
    {
        Context = context; //Context: Nombre de la propiedad. Aquí se almacena la instancia del contexto de la base de datos que permite interactuar con la base de datos.
    } // Asigna el valor del parámetro context a la propiedad Context de la clase. Esto permite que la clase AssignmentsController utilice el contexto de la base de datos para realizar operaciones.
}
