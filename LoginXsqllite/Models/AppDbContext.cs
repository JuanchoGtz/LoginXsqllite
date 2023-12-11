using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginXsqllite.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string nombreBaseDeDatos = "Escuela.db3"; 
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, nombreBaseDeDatos);
            Console.WriteLine($"La base de datos se encuentra en: {databasePath}");
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

    }
}
