using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_Nemura.Models;

namespace WebAPI_nemura.Data;

public class ApplicationDbContext : DbContext
{
    //Propiedades del ConnectionDbContext??? para hacer referencia a nuestras clases de Models. Y poderlas enlazarlas con la base de datos
public DbSet<User> Users {get; set;} // por que se pone DbSet???
public DbSet<Project> Projects {get; set;}
public DbSet<Assignment> Assignments {get; set;}

// Constructor del ConnectionDbContext???.
public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options): base (options)
{
    
}
}
