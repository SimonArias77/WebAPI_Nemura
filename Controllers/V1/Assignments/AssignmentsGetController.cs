using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_nemura.Data;
using WebAPI_Nemura.Dtos.Assignment;

namespace WebAPI_Nemura.Controllers.V1.Assignments;//Aqui tenemos:  las data annotation [Authorize], [ApiController], [Route]. Luego la clase como tal y la herencia. Luego el contructor. Luego los metodos GET: genral, por id, por projectId.

[Authorize] // se utiliza para aplicar la autorización a los métodos o a la clase completa en un controlador. Su función es proteger el endpoint, asegurando que solo los usuarios autenticados (o que cumplen con ciertos requisitos de autorización) puedan acceder a los recursos que maneja este controlador.
[ApiController] // todos los endpoints deben tener esta data annotation. Esta annotation indica que la clase es un controlador de API. Esto activa varias características que facilitan la creación de APIs RESTful,
[Route("api/v1/assignments")] // es la ruta para enlazar base de datos con proyecto
public class AssignmentsGetController : ControllerBase //Al heredar de esta clase, el controlador obtiene funcionalidades básicas para manejar solicitudes HTTP. ControllerBase es una clase base que ofrece métodos y propiedades útiles, como el manejo de respuestas, acceso al contexto de la solicitud, etc.
{
    private readonly ApplicationDbContext Context; //Esta línea declara una propiedad privada llamada Context que es de tipo ApplicationDbContext
                                                   // readonly: ndica que la propiedad solo puede ser asignada durante la declaración o en el constructor, lo que ayuda a garantizar que el contexto de la base de datos no se modifique accidentalmente después de ser inicializado.
                                                   //ApplicationDbContext: Es una clase que generalmente se utiliza para interactuar con la base de datos, configurada mediante Entity Framework Core. Contiene propiedades que representan las tablas en la base de datos y permite realizar operaciones de CRUD (Crear, Leer, Actualizar, Borrar).
                                                   //Constructor
    public AssignmentsGetController(ApplicationDbContext context) // constructor de la clase:
    {
        Context = context;  //public: El constructor es público, lo que permite que se pueda crear una instancia de este controlador desde otras partes de la aplicación
    } //ApplicationDbContext context: Este parámetro permite inyectar una instancia de ApplicationDbContext al controlador. Esta inyección de dependencia es una práctica común en ASP.NET Core que mejora la modularidad y facilita las pruebas.
      //Context = context; Esta línea asigna el parámetro context a la propiedad Context.Asignación: Aquí, se está guardando la instancia de ApplicationDbContext recibida en el constructor en la propiedad Context. Esto permite que el controlador utilice esta instancia para realizar operaciones en la base de datos más adelante, como consultar o manipular datos.


    [HttpGet]

    public async Task<ActionResult<List<AssignmentGetDto>>> Get() // Aquí se define el método Get, que es público y asíncrono (async). Devuelve un Task que resultará en un ActionResult que contiene una lista de objetos AssignmentGetDto. El uso de Task permite realizar operaciones asíncronas, mejorando la eficiencia de la API.
    {
        var assignments = await Context.Assignments.Select(
            assignment => new AssignmentGetDto
            {
                Id = assignment.Id,
                Name = assignment.Name,
                Description = assignment.Description,
                Status = assignment.Status,
                Priority = assignment.Priority,
                ProjectId = assignment.ProjectId
            }).ToListAsync();

        if (assignments == null)
        {
            return NoContent();
        }

        return Ok(assignments);
    }

    [HttpGet("ById/{id}")]

    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var assignmentFound = await Context.Assignments.FindAsync(id);

        if (assignmentFound == null)
        {
            return NotFound("Assignment not found");
        }

        var assignments = await Context.Assignments.Select(
            assignment => new
            {
                assignment.Id,
                assignment.Name,
                assignment.Description,
                assignment.Status,
                assignment.Priority,
                assignment.Project
            }
        ).ToListAsync();
        return Ok(assignments);
    }

    [HttpGet("ByProjectId/{id}")]

    public async Task<IActionResult> GetAssignmentsByProjectId([FromRoute] int id)
    {
        var assignments = await Context.Assignments
                                        .Where(assignment => assignment.ProjectId == id)
                                        .Select(assignment => new
                                        {
                                            assignment.Id,
                                            assignment.Name,
                                            assignment.Description,
                                            assignment.Status,
                                            assignment.Priority,
                                            assignment.ProjectId
                                        }).ToListAsync();

        if (assignments == null)
        {
            return NotFound("No tasks found for the specified project");
        }

        return Ok(assignments);
    }

}
