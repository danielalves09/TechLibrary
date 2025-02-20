using Microsoft.EntityFrameworkCore;
using TechLibrary.Api.Domain.Entities;
namespace TechLibrary.Api.Infraestructure.DataAcess
{
    public class TechLibraryDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\CURSOS\\REPOSITORIOS\\NWL - ROCKETSEAT\\TechLibrary\\BD\\TechLibraryDb.db");
            
        
        
        }
    }
}
