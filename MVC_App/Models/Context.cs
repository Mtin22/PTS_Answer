using Microsoft.EntityFrameworkCore;

namespace MVC_App.Models;

public class Context : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Register> Register { get; set; }

    public Context(DbContextOptions options) : base(options)
    {

    }
}