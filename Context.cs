using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sport
{
  public class Context : DbContext
  {
    private readonly string connectionString;

    public Context(string connectionString)
    {
      this.connectionString = connectionString;
      Database.EnsureCreated();
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      var realMadrid = new Team { Name = "Real Madrid" };
      var atletico = new Team { Name = "Atletico" };
      var barcelona = new Team { Name = "Barcelona" };

      builder.Entity<Team>().HasData(realMadrid);
      builder.Entity<Team>().HasData(atletico);
      builder.Entity<Team>().HasData(barcelona);

      builder.Entity<Player>().HasData(new Player { FullName = "Sergio Ramos", TeamId = realMadrid.Id });
      builder.Entity<Player>().HasData(new Player { FullName = "Tony Kroos", TeamId = realMadrid.Id });
      builder.Entity<Player>().HasData(new Player { FullName = "Keylor Navas", TeamId = realMadrid.Id });

      builder.Entity<Player>().HasData(new Player { FullName = "Antouane Grizmane", TeamId = atletico.Id });
      builder.Entity<Player>().HasData(new Player { FullName = "Diego Costa", TeamId = atletico.Id });
      builder.Entity<Player>().HasData(new Player { FullName = "Fernandinho", TeamId = atletico.Id });

      builder.Entity<Player>().HasData(new Player { FullName = "Lionel Messi", TeamId = barcelona.Id });
      builder.Entity<Player>().HasData(new Player { FullName = "Ousmane Dembele", TeamId = barcelona.Id });
      builder.Entity<Player>().HasData(new Player { FullName = "Luis Suarez", TeamId = barcelona.Id });
    }
  }
}
