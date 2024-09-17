using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_Nemura.Models;

namespace WebAPI_nemura.Data;

// ApplicationDbContext: Tipo de la propiedad. Es una clase que representa el contexto de la base de datos en Entity Framework Core, la cual maneja la conexión y las operaciones con la base de datos.
public class ApplicationDbContext : DbContext
{
    //Propiedades del ApplicationDbContext para hacer referencia a nuestras clases de Models. Y poderlas enlazarlas con la base de datos
public DbSet<User> Users {get; set;} // por que se pone DbSet???
public DbSet<Project> Projects {get; set;}
public DbSet<Assignment> Assignments {get; set;}

// Constructor del ApplicationDbContext.
public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options): base (options)
{

}
}
