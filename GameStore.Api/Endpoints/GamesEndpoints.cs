using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
  const string GetGameEndpointName = "GetGame";
  public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("games").WithParameterValidation();

    // GET /games
    group.MapGet("/", async (GameStoreContext dbContext) =>
    {
      var games = await dbContext.Games
        .Include(g => g.Genre)
        .Select((game) => game.ToGameSummaryDto()).AsNoTracking().ToListAsync();

      return Results.Ok(games);
    });

    // GET /games/1
    group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
    {
      Game? game = await dbContext.Games.FindAsync(id);

      return game is null ?
        Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
    }).WithName(GetGameEndpointName);

    // POST /games
    group.MapPost("/", async (CreateGameDto gameDto, GameStoreContext dbContext) =>
    {
      Game game = gameDto.ToEntity();

      dbContext.Games.Add(game);
      await dbContext.SaveChangesAsync();

      return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameDetailsDto());
    });

    // PUT /games/id
    group.MapPut("/{id}", async (int id, UpdateGameDto gameDto, GameStoreContext dbContext) =>
    {
      var existingGame = await dbContext.Games.FindAsync(id);

      if (existingGame is null) return Results.NotFound();

      dbContext.Entry(existingGame).CurrentValues.SetValues(gameDto.ToEntity(id));
      await dbContext.SaveChangesAsync();

      return Results.NoContent();
    });

    // DELETE /games/id
    group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
    {
      // Batch delete without fetching the entity first
      // most efficient way to delete a records from the database tables
      await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

      return Results.NoContent();
    });

    return group;
  }
}
