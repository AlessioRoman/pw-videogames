using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using pw_videogames.Models;

namespace pw_videogames.Database
{
    public class VideogameContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<VideogameModel> Videogames { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:projectwork3.database.windows.net,1433;Initial Catalog=GamesDb;Persist Security Info=False;User ID=master;Password=ProjectWork3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
