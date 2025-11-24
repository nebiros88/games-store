using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;
// can be simplified => public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
public class GameStoreContext : DbContext
{
  // take options into the class constructor and pass them to the base class constructor
  public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
  { }

  // creating db set instances for each entity
  public DbSet<Game> Games => Set<Game>();
  public DbSet<Genre> Genres => Set<Genre>();

  override protected void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Genre>().HasData(
      new { Id = 1, Name = "Fighting" },
      new { Id = 2, Name = "Roleplaying" },
      new { Id = 3, Name = "Sports" },
      new { Id = 4, Name = "Racing" },
      new { Id = 5, Name = "Kids and Family" }
    );
  }

}
